using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {
    public float enemySpeed;
    Rigidbody2D enemyRB;
    Rigidbody2D childrenRB;

    Animator enemyAnimation;
    // Use this for initialization
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime=5f;
    float nexFlip=0f;
    bool canFlip = true;
    GameObject enemy;

    void Awake() {

        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimation = GetComponentInChildren<Animator>();
        
    }

	void Start () {
        
    }

    // Update is called once per frame


    void Update () {
     
        
        if (Time.time > nexFlip)
        {
            nexFlip = Time.time + facingTime;
            Flip();
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Main Character")
        {
            if (!other.gameObject.GetComponent<PlayerHealth>().isAlive)
            {
                enemyAnimation.SetFloat("speed", 0);
                return;

            }
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                Flip();
            }else if(!facingRight && other.transform.position.x > transform.position.x)
            {
                Flip();
            }
            canFlip = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag=="Main Character")
        {
            if(!other.gameObject.GetComponent<PlayerHealth>().isAlive)
            {
                enemyAnimation.SetFloat("speed", 0);
                return;
            }
            if (!facingRight)
            {
               enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else
            {
               enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            }
            enemyAnimation.SetFloat("speed", enemySpeed);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Main Character")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
            enemyAnimation.SetFloat("speed", 0);
        }
    }

    void Flip() {
        if (!canFlip) return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
