using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

    public float weaponDamage;          //damage per fire
    projecttileController myPC;         //control the projecttitle

    public GameObject bulletExplosion;

    void Awake()
    {
        myPC = GetComponentInParent<projecttileController>();   //get controller
    }
    
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}


    /*When the bullet hit enemy */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootable"|| other.gameObject.tag == "Ground")
        {
            myPC.removeForce();                                                         //turn of the projecttile force
            Instantiate(bulletExplosion, transform.position, transform.rotation);       //create explotion effect
            Destroy(gameObject);                                                        //destroy the bullet
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {   
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDame(weaponDamage);                                        //decrease the health of enemy
            }
        }
    }

    /*When the bullet hit and stay in enemy */
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootable")
        {
            myPC.removeForce();                                                         //turn of the projecttile force
            Instantiate(bulletExplosion, transform.position, transform.rotation);       //create explotion effect
            Destroy(gameObject);                                                        //destroy the bullet
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDame(weaponDamage);                                        //decrease the health of enemy
            }
        }
    }
}
