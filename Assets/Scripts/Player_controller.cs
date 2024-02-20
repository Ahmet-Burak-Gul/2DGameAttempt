using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator PlayerAnimator;

    public int moveSpeaed = 1;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime;
    bool facingRight = true;
    
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }
    void Update()
    {        
        HorizontalMove();
        OnGroundedCheck();
        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && nextJumpTime < Time.timeSinceLevelLoad)
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeaed, playerRB.velocity.y);
        PlayerAnimator.SetFloat("PlayerSpeed",Mathf.Abs(playerRB.velocity.x));
    }

    void Jump()
    {
        //playerRB.velocity = new Vector2(playerRB.velocity.x, Input.GetAxis("Vertical") * jumpSpeed); 
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }

    void OnGroundedCheck()
    {
        isGrounded = Physics2D.OverlapCircle( groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        PlayerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}