using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float leftRightSpeed;
    public GameObject playerObject;
    public GameObject gameOverMenu;
    public GameObject score;
    public TMP_Text finalScore;

    //Jump parameters
    public bool isJumping;
    public bool comingDown;
    public static int jumpPower;
    public static float jumpDuration;
    //Animator animator;

    private float speedIncreaseRate = 0.2f; // Adjust the rate of speed increase here

    void Start()
    {
        score.SetActive(true);
        moveSpeed = 10;
        leftRightSpeed = 10;
        isJumping = false;
        comingDown = false;
        jumpPower = 5;
        jumpDuration = 0.45f;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed += speedIncreaseRate * Time.deltaTime; // Increase moveSpeed over time
        //Debug.Log("Move speed: " + moveSpeed);

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.x > Boundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.transform.position.x < Boundary.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJumping)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump2");
                StartCoroutine(JumpSequence());
            }
        }

        if (isJumping)
        {
            if (!comingDown) //Upward movement lasts 0.45sec
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpPower, Space.World);
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * -jumpPower, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(jumpDuration); //while player is jumping up
        comingDown = true;
        yield return new WaitForSeconds(jumpDuration);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run (2)");
    }

    public void GameOver(int currScore)
    {
        finalScore.text = currScore.ToString();
        Debug.Log("gameover called");
        Time.timeScale = 0;
        score.SetActive(false);
        gameOverMenu.SetActive(true);

    }

}
