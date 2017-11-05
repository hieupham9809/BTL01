﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float MaxSpeed;
    public float JumpHeight;
    Rigidbody2D myBody;
    Animator myAnim;
    bool facingRight;
    public GameObject MainCharacter;
    bool Grounded;
 
	// Use this for initialization
	void Start () {
       
        myBody =GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
       
        facingRight = true;
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {       
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));//set animation for running
        
        myBody.velocity = new Vector2(move * MaxSpeed, myBody.velocity.y);
        
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight) {
            flip();
        }
       
        if (Input.GetKey(KeyCode.Space)) {
            if (Grounded)
            {
                Grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, JumpHeight);
            }
        }

       
       
        
	}
    //flip the face of character
    void flip() {
        facingRight = !facingRight;
        Vector3 theScale =transform.localScale;
        theScale.x *= -1;
       transform.localScale = theScale;
    }
  
  

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            Grounded = true;
        }
    }
}
