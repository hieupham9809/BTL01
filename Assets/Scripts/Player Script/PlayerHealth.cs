using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int MaxHealth;           // Maximum health for player
    int currentHealth;              // current health
    public GameObject BloodEffect;  // the effect when player died
    Animator myAnim;                //use to get animation of main character
    public bool isAlive;            // when player died, set to false
    PlayerController control;       //use to control the main character
    bool hurt;                      // use to control the main character animation
    float nexthurt;                 // the time before next hurt

    //link to health slither
    public Slider PlayerHealthSlither;

    //sound player when player died
   
    AudioSource DyingSound;
    AudioSource hurtSound;
    
    //sound when player hurt
    public AudioClip hurtSoundClip;
    public AudioClip DyingSoundClip;
    

    // Use this for initialization
    void Start () {
        /*add audiosource for sounds*/
   

        //hurt sound
        hurtSound = gameObject.AddComponent<AudioSource>();
        hurtSound.clip = hurtSoundClip;
        hurtSound.Stop();                                       // stop this sound when star game

        //Dying sound
        DyingSound = gameObject.AddComponent<AudioSource>();
        DyingSound.clip = DyingSoundClip;
        DyingSound.Stop();                                      // stop this sound when star game

        //health slidther
        PlayerHealthSlither.maxValue = MaxHealth;
        PlayerHealthSlither.value = MaxHealth;
        
        /*Khoi tao mot vai dac tinh*/
        currentHealth = MaxHealth; 
        myAnim = GetComponent<Animator>();                      // get animation of the main character
        control = gameObject.GetComponent<PlayerController>();  // get controller of the main character
        isAlive = true;                                         // set alive is true
        nexthurt = 0f; 
    }
	
	// Update is called once per frame
	void FixedUpdate () {       
        // set slither value = current health
        PlayerHealthSlither.value = currentHealth;

        //set animation for die
        myAnim.SetBool("Alive", isAlive);

        //set animation for hurt
        if(hurt==true && nexthurt < Time.time)
        {
            myAnim.SetBool("Hurt", false);
            nexthurt = Time.time + 2;
        }

        //if isAlive=false -> die
        if (!isAlive)
        {
            makeDeath();
        }

        //if position of Y < -10 -> die
        if (transform.position.y < -10)
        {
            isAlive = false;
        }
    }


    /* eat health item to add health */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Health Item")
        {
            Destroy(other.gameObject);  //destroy health item
            AddHealth();                //add health for player     
        }
       
    }


    /*taking damage from enemies*/
   public void addDamage(bool dam)
    {
        hurt = true;                    // set hurt to true
        myAnim.SetBool("Hurt", true); 
        hurtSound.Play();               //play hurt sound

        if (!dam) return;
        currentHealth--;                //decrease the health

        //when health <= 0
        if (currentHealth <= 0)
        {
            isAlive = false;           
            DyingSound.Play();          // phay dying sound          
        }       
    }


    /*making deadth function*/
    void makeDeath()
    {
        //when player dead, he can't move
        control.MaxSpeed = 0;
        control.JumpHeight = 0;
        //make animation when player dies
        if (isAlive == false && myAnim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {            
            Instantiate(BloodEffect, transform.position, transform.rotation);   // blood effect
            gameObject.SetActive(false);                                        //inactive the main character
            FindObjectOfType<Manager>().GameOver();                             //show the gameover menu
        }               
    }


    /* Add Health function */
    void AddHealth()
    {
        if (currentHealth == MaxHealth) return; // not add health when current health == max health
        currentHealth++;
    }
    
}
