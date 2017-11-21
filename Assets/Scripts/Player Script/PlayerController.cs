using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float MaxSpeed;          // set the maximum speed
    public float JumpHeight;        // set the maximum jump height
    Rigidbody2D myBody;             // this variable to get the main character rigitbody2D component
    Animator myAnim;                // this variable to get the main character animation component
    bool facingRight;               // indentified the direction of main character
    public GameObject MainCharacter;
    bool Grounded;                  // indentified the gound to jump
    public Transform gunTip;        // the place where bullet is fired
    public GameObject bullet;       // the bullet
    float fireRate = 0.7f;          // the minimum time between 2 fires
    float nextFire = 0;             // the time before next fire

    // Jumping sound
    AudioSource JumpAudioSource; 
    public AudioClip JumpClip;


    // Use this for initialization

    void Awake() {
        //add Jumping sound to audio source component
        JumpAudioSource = gameObject.AddComponent<AudioSource>();
        JumpAudioSource.clip = JumpClip;
        JumpAudioSource.Stop();
    }
    
    void Start () {
       //get rigitbody2D and animation of main character
        myBody =GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
       //set facingright 
        facingRight = true;       
	}
	
    
	// Update is called once per frame
	void FixedUpdate () {
        myAnim.SetBool("attack", false);                                    //set animation for attacking

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));                          //set animation for running
        
        myBody.velocity = new Vector2(move * MaxSpeed, myBody.velocity.y);  // add a force to moving
        
        if (move > 0 && !facingRight)
        {
            flip();                                                         //flip the face
        }

        else if (move < 0 && facingRight) {
            flip();                                                         //flip the face
        }

       /*code to jump*/
        if (Input.GetKey(KeyCode.Space)||Input.GetAxis("Vertical")>0) {
            if (Grounded)                                                       //if main character is staying on ground, he can jumps
            {
                Grounded = false;                                               //set grounded to false
                myBody.velocity = new Vector2(myBody.velocity.x, JumpHeight);   //add force to jump
                JumpAudioSource.Play();                                         //play jumping sound
            }
        }


        /* fire */
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();       //fire the bullet
        }
    }


    /*flip the face of character */
    void flip() {
        facingRight = !facingRight;
        Vector3 theScale =transform.localScale;
        theScale.x *= -1;
       transform.localScale = theScale;
    }
  
  
    /* Collider function */
    void OnCollisionEnter2D(Collision2D other) {
        //check if main character is staying on ground
        if (other.gameObject.tag == "Ground"||other.gameObject.tag=="Enemy") {
            Grounded = true;
        }

        //eat gold item to add point
        if (other.gameObject.tag == "Gold Item")
        {
            Destroy(other.gameObject);                  // destroy the gold item
            FindObjectOfType<Score>().AddPoint(200);    //add point           
        }

        //Continue the next level
        if (other.gameObject.tag == "Gate")
        {
            if (Application.loadedLevelName == "level1")
            {

                Application.LoadLevel("Level_boss");    //move to level boss
            }

            if (Application.loadedLevelName == "Level_boss")
            {
                FindObjectOfType<Manager>().winningGame();  //end game
            }
        }
    }


    //Fire funcion
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            myAnim.SetBool("attack", true);//set attacking animation
            nextFire = Time.time + fireRate;

            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));//create a bullet
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));//create a bullet
            }
            
        }
    }

}
