﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Rigidbody2D playerRigidbody2D;
    private Animator playerAnim;
    private SpriteRenderer playerSpriteImage;

    private float movePlayerHorizontal;
    private float movePlayerVertical;
    private Vector2 movement;

    public float speed = 4.0f;

    void Awake()
    {
        playerRigidbody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        playerAnim = (Animator)GetComponent(typeof(Animator));
        playerSpriteImage = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerHorizontal = Input.GetAxis("Horizontal");
        movePlayerVertical = Input.GetAxis("Vertical");
        movement = new Vector2(movePlayerHorizontal, movePlayerVertical);
        playerRigidbody2D.velocity = movement * speed;

        if(movePlayerVertical==0 && movePlayerHorizontal == 0)
        {
            playerAnim.SetBool("moving", false);
        }
        else
        {
            playerAnim.SetBool("moving", true);
        }

        if (movePlayerVertical != 0)
        {
            playerAnim.SetBool("xMove", false);
            playerSpriteImage.flipX = false;

            if (movePlayerVertical > 0)
            {
                playerAnim.SetInteger("yMove", 1);

            }
            else if (movePlayerVertical < 0)
            {
                playerAnim.SetInteger("yMove", -1);

            }
        }
        else
        {
            playerAnim.SetInteger("yMove", 0);

            if (movePlayerHorizontal > 0)
            {
                playerAnim.SetBool("xMove", true);
                playerSpriteImage.flipX = false;

            }
            else if (movePlayerHorizontal < 0)
            {
                playerAnim.SetBool("xMove", true);
                playerSpriteImage.flipX = true;

            }
            else
            {
                playerAnim.SetBool("xMove", false);
            }
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	

}
