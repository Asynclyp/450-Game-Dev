using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float leftRightSpeed;
    //Animator animator;

    private float speedIncreaseRate = 0.2f; // Adjust the rate of speed increase here

    void Start()
    {
        moveSpeed = 10;
        leftRightSpeed = 10;
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
            transform.Translate(Vector3.up * Time.deltaTime * leftRightSpeed);
            //animator.SetBool("Jump", true);
            //Debug.Log("Jump!");
        }

        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") &&
        //        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= Time.deltaTime)
        //{ 
        //    // Reset the Animator's jump bool
        //    animator.SetBool("Jump", false);
        //}

    }
}
