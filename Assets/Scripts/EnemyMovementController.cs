using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {
    public float enemySpeed;
    Rigidbody2D enemyRB;
    Animator enemyAnimation;
    // Use this for initialization
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime=5f;
    float nexFlip=0f;
    bool canFlip = true;

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

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
