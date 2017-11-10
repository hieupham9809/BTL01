using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

    public float weaponDamage;
    projecttileController myPC;

    public GameObject bulletExplosion;

    void Awake()
    {
        myPC = GetComponentInParent<projecttileController>();
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootable")
        {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDame(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootable")
        {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDame(weaponDamage);
            }
        }
    }
}
