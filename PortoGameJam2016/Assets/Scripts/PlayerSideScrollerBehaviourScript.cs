﻿using UnityEngine;
using System.Collections;

public class PlayerSideScrollerBehaviourScript : MonoBehaviour {
    //local variables
    bool isGrounded = true;

    //settings for game
    public float speed = 10.0F;
    public float speedAir = 10.0F;
    public float jumpSpeed = 10.0f;
    public float maxSpeedGround = 10.0f;
    public float maxSpeedAir = 10.0f;
    public float horizontalDrag = 15f;
    public GameObject parentObject;

    private float maxSpeed = 0;

    void Start () {

    }
	
	void FixedUpdate () {

        if (GameManager.Instance.CurrentMode == Mode.SideScroller)
        {
            
            float translationX = Input.GetAxisRaw("Horizontal");
            float translationY = Input.GetAxisRaw("Vertical");
  
            var currentVel = GetComponent<Rigidbody2D>().velocity;

            var vel = new Vector2(translationX, 0).normalized;
            Vector2 jumpVel = Vector2.zero;
            if (translationY > 0 && isGrounded)
            {
                jumpVel = jumpSpeed * Vector2.up;
            }
            
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().drag = horizontalDrag;
                maxSpeed = maxSpeedGround;
                vel *= speed;
            }
            else
            {
                GetComponent<Rigidbody2D>().drag = 0.5f ;
                maxSpeed = maxSpeedAir;
                vel *= speedAir;
            }
            currentVel += (jumpVel + vel);
            currentVel.x = Mathf.Clamp(currentVel.x, -maxSpeed, maxSpeed);

            GetComponent<Rigidbody2D>().velocity = currentVel;
        }
    }

    //consider when character is falling and touches the ground, it will enter collision.
    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        } else if (collision.gameObject.tag == "Enemy")
        {
            parentObject.GetComponent<PlayerController>().OnCollisionEnterChild();
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
