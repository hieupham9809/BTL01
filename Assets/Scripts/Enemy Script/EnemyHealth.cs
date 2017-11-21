using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int point=100;               //point for each enemy  
	// Use this for initialization
	public float maxHealth;             //max health for enemy
	float currentHealth;                //current health for enemy
   
	//bien de tao hieu ung khi enemy die
	public GameObject enemyHealthEF;    //blood effect for enemy

	//bien de tao thanh mau cho enemy
	public Slider enemyHealthSlider;    //blood slither of enemy


	void Start () {
		currentHealth = maxHealth;                  //set current health
		enemyHealthSlider.maxValue = maxHealth;     //set health slither max value
		enemyHealthSlider.value = maxHealth;        //set health slither value
	}
	
	// Update is called once per frame
	void Update () {
        enemyHealthSlider.value = currentHealth;                //update health slither value
        if (transform.position.y < -10) Destroy(gameObject);    //enemy die when it fall down
    }


    /* add damage function */
	public void addDame(float dame){
		enemyHealthSlider.gameObject.SetActive (true);          //show enemy health slither
		currentHealth -= dame;                                  //decrease current health
		//die when current health <= 0
		if (currentHealth <= 0)	makeDead ();
        
    }


    /* Making deadth function */
	void makeDead(){
        FindObjectOfType<Score>().AddPoint(point);                              //add score for player
        Instantiate(enemyHealthEF, transform.position, transform.rotation);     //create blood effect
        Destroy (gameObject);                                                   //destroy enemy object
        Destroy(transform.root.gameObject);
	}
}
