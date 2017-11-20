using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {
    public float enemySpeed;            //speed for enemy
    Rigidbody2D enemyRB;                //get rigibody2D for enemy
    Animator enemyAnimation;            //get animation
    // Use this for initialization
    public GameObject enemyGraphic;     //the enemy target
    bool facingRight = true;            //direct of facing 
    float facingTime=5f;                //time of facing
    float nexFlip=0f;                   
    bool canFlip = true;                //check whether enemy could flip face

    void Awake() {
        enemyRB = GetComponent<Rigidbody2D>();                  //get rigibody2D component
        enemyAnimation = GetComponentInChildren<Animator>();    //get animation component        
    }


	void Start () {        
    }

    // Update is called once per frame

        void FixedUpdate()
    {
        if (!enemyAnimation) Destroy(gameObject);           //destroy this object when enemy has been destroy

    }
    
    void Update () {        
        
        //flip the face after facingtime
        if (Time.time > nexFlip)
        {
            nexFlip = Time.time + facingTime;
            Flip();                                         //flip the face
        }
	}


    /*Collise when player enter the collider */
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Main Character")
        {
            if (!other.gameObject.GetComponent<PlayerHealth>().isAlive)
            {
                enemyAnimation.SetFloat("speed", 0);            //stop if player dead
                return;

            }
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                Flip();                                         //flip the face to the player
            }else if(!facingRight && other.transform.position.x > transform.position.x)
            {
                Flip();                                         //flip the face to the player
            }
            canFlip = false;
        }
    }


    /*Collise when player stay in the collider */
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag=="Main Character")
        {
            if (!other.gameObject.GetComponent<PlayerHealth>().isAlive)
            {
                enemyAnimation.SetFloat("speed", 0);                //stop if player dead
                return;
            }
            if (!facingRight)
            {
               enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);   //add force to chase the player
            }
            else
            {
               enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);    //add force to chase the player
            }
            enemyAnimation.SetFloat("speed", enemySpeed);
        }
    }


    /*Collise when player exit the collider */
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Main Character")
        {
            canFlip = true;                             //set can flip
            enemyRB.velocity = new Vector2(0, 0);       //set the force to 0
            enemyAnimation.SetFloat("speed", 0);        //idle animation
        }
    }


    /*Flip function */
    void Flip() {
        if (!canFlip) return;                   
        facingRight = !facingRight;                             //Flip the face!!
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;           //update enemy scale
    }
}
