using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
    float damrate = 0.5f;
    float nextdam ;
    public float pushBackForce;
    // Use this for initialization
    void Start () {
        nextdam = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Main Character" && nextdam<Time.time)
        {           
            PlayerHealth myPlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            myPlayerHealth.addDamage(true);
            nextdam = damrate + Time.time;
           
        }
        
    }

}
