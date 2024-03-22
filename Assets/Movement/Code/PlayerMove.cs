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

    public bool isJumping;
    public bool comingDown;
    //Animator animator;

    private float speedIncreaseRate = 0.2f; // Adjust the rate of speed increase here

    void Start()
    {
        score.SetActive(true);
        moveSpeed = 10;
        leftRightSpeed = 10;
        isJumping = false;
        comingDown = false;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed += speedIncreaseRate * Time.deltaTime; // Increase moveSpeed over time
        Debug.Log("Move speed: " + moveSpeed);

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
            //transform.Translate(Vector3.up * Time.deltaTime * leftRightSpeed);
            //animator.SetBool("Jump", true);
            //Debug.Log("Jump!");
        }

        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 5, Space.World);
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * -5, Space.World);
            }
        }

        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") &&
        //        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= Time.deltaTime)
        //{ 
        //    // Reset the Animator's jump bool
        //    animator.SetBool("Jump", false);
        //}

    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
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
