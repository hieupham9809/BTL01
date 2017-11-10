using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int point=100;
	// Use this for initialization
	public float maxHealth;
	float currentHealth;
   
	//bien de tao hieu ung khi enemy die
	public GameObject enemyHealthEF;

	//bien de tao thanh mau cho enemy
	public Slider enemyHealthSlider;


	void Start () {
		currentHealth = maxHealth;
		enemyHealthSlider.maxValue = maxHealth;
		enemyHealthSlider.value = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addDame(float dame){
		enemyHealthSlider.gameObject.SetActive (true);
		currentHealth -= dame;
		enemyHealthSlider.value = currentHealth;
		if (currentHealth <= 0)	makeDead ();
        
    }

	void makeDead(){
        FindObjectOfType<Score>().AddPoint(point);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
        Destroy (gameObject);
		
	}
}
