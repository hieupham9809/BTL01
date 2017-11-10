using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int MaxHealth;
    int currentHealth;
    public GameObject BloodEffect;
    PlayerController player;
    Animator myAnim;
    public bool isAlive;
    PlayerController control;
    bool hurt;
    float nexthurt;

    //sound for player
    AudioSource DyingSound;
    AudioSource hurtSound;
    public AudioClip hurtSoundClip;
    public AudioClip DyingSoundClip;
    // Use this for initialization
    void Start () {
        /*add audiosource for sounds*/
        //hurt sound
        hurtSound = gameObject.AddComponent<AudioSource>();
        hurtSound.clip = hurtSoundClip;
        hurtSound.Stop();
        //Dying sound
        DyingSound = gameObject.AddComponent<AudioSource>();
        DyingSound.clip = DyingSoundClip;
        DyingSound.Stop();
        /*Khoi tao mot vai dac tinh*/
        currentHealth = MaxHealth;
        myAnim = GetComponent<Animator>();
        control = gameObject.GetComponent<PlayerController>();
        isAlive = true;
        nexthurt = 0f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        myAnim.SetBool("Alive", isAlive);//set animation for die
        if(hurt==true && nexthurt < Time.time)
        {
            myAnim.SetBool("Hurt", false);
            nexthurt = Time.time + 2;
        }
        if (!isAlive)
        {
            makeDeath();
        }
        if (transform.position.y < -10) gameObject.SetActive(false);
    }
    //ham nhan damage
   public void addDamage(bool dam)
    {
        hurt = true;
        myAnim.SetBool("Hurt", true);
        hurtSound.Play();
        if (!dam) return;
        currentHealth--;
        if (currentHealth <= 0)
        {
            isAlive = false;
            DyingSound.Play();
        }
       
    }
    //ham chet
    void makeDeath()
    {
        control.MaxSpeed = 0;
        if (isAlive == false && myAnim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            
            Instantiate(BloodEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }

        
        
    }

    
}
