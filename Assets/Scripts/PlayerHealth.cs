using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int MaxHealth;
    int currentHealth;
    public GameObject BloodEffect;
	// Use this for initialization
	void Start () {
        currentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

   public void addDamage(bool dam)
    {
        if (!dam) return;
        currentHealth-=1;
        if (currentHealth <= 0)
        {
            makeDeath();
        }
    }

    void makeDeath()
    {
        Instantiate(BloodEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

}
