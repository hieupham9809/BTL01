using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
    float damrate = 1f;         //the minimum time between 2 dams
    float nextdam ;             //the time before next dam
    Animator anim;              //to get the animation of enemy

    // Use this for initialization
    void Start () {
        nextdam = 0f;                       //set next dam
        anim = GetComponent<Animator>();    //get the animtion
    }
	
	// Update is called once per frame
	void FixedUpdate () {	
	}

    /*Collise when player enter the collider*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Main Character" && nextdam<Time.time)
        {
            //if player dead
            if (!other.gameObject.GetComponent<PlayerHealth>().isAlive)
            {
                anim.SetBool("attack", false);  //set attacking animation
                return;
            }

            //if player still alive
            anim.SetBool("attack", true);       //set attacking animation         
            PlayerHealth myPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            myPlayerHealth.addDamage(true);     //add damage for player
            nextdam = damrate + Time.time;      //update the next dam           
        }        
    }


    /*Collise when player stay in the collider*/
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Main Character" && nextdam < Time.time)
        {
            if (!other.gameObject.GetComponent<PlayerHealth>().isAlive)
            {
                anim.SetBool("attack", false);  //set attacking animation
                return;
            }

            //if player still alive
            anim.SetBool("attack", true);       //set attacking animation    
            PlayerHealth myPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();            
            myPlayerHealth.addDamage(true);     //add damage for player
            nextdam = damrate + Time.time;      //update the next dam

        }
    }


    /*Collise when player exit the collider*/
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Main Character")
        {
            anim.SetBool("attack", false);      //set attacking animation
        }
    }

}
