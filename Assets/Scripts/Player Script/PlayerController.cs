using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float MaxSpeed;
    public float JumpHeight;
    Rigidbody2D myBody;
    Animator myAnim;
    bool facingRight;
    public GameObject MainCharacter;
    bool Grounded;
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 1.0f;
    float nextFire = 0;
    AudioSource JumpAudioSource;
    public AudioClip JumpClip;
    // Use this for initialization

    void Awake() {
        JumpAudioSource = gameObject.AddComponent<AudioSource>();
        JumpAudioSource.clip = JumpClip;
        JumpAudioSource.Stop();
    }
    
    void Start () {
       
        myBody =GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
       
        facingRight = true;
       
	}
	
    
	// Update is called once per frame
	void FixedUpdate () {       
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));//set animation for running
        myAnim.SetBool("attack", false);
        myBody.velocity = new Vector2(move * MaxSpeed, myBody.velocity.y);
        
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight) {
            flip();
        }
       
        if (Input.GetKey(KeyCode.Space)||Input.GetAxis("Vertical")>0) {
            if (Grounded)
            {
                Grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, JumpHeight);
                JumpAudioSource.Play();              
            }
        }
        //Chuc nang bang tu ban phim
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();
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
        if (other.gameObject.tag == "Ground"||other.gameObject.tag=="Enemy") {
            Grounded = true;
        }
    }
    //Chuc nang ban
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            myAnim.SetBool("attack", true);
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            
        }
    }
}
