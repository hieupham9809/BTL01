using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
    float damrate = 0.5f;
    float nextdam ;
    Animator anim;
    // Use this for initialization
    void Start () {
        nextdam = 0f;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Main Character" && nextdam<Time.time)
        {
            if (!other.gameObject.GetComponent<PlayerHealth>().isAlive)
            {
                anim.SetBool("attack", false);
                return;
            }
            anim.SetBool("attack", true);         
            PlayerHealth myPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (myPlayerHealth.isAlive == false) return;
            myPlayerHealth.addDamage(true);
            nextdam = damrate + Time.time;
           
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Main Character" && nextdam < Time.time)
        {
            if (!other.gameObject.GetComponent<PlayerHealth>().isAlive)
            {
                anim.SetBool("attack", false);
                return;
            }
            anim.SetBool("attack", true);            
            PlayerHealth myPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (myPlayerHealth.isAlive == false) return;
            myPlayerHealth.addDamage(true);
            nextdam = damrate + Time.time;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Main Character")
        {
            anim.SetBool("attack", false);
        }
    }

}
