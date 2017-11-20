﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour
{
   
    public GameObject gameovermenu; // using gameover menu
    private GameObject title;       //calling the title 

    //Background sounds
    AudioSource BackgroundSound;
    public AudioClip BackgroundClip;

    //Game over sounds
    AudioSource GameoverSound;
    public AudioClip GameoverClip;

    //Enter game sounds
    AudioSource EnterGameSound;
    public AudioClip EnterGameClip;

    public GameObject character;    //calling the main character

    // Use this for initialization
    void Awake()
    {
        Time.timeScale = 0;                 //pause the game until player press any key
        gameovermenu.SetActive(false);      //turn off game over menu
        title = GameObject.Find("Title");   //find the title
       
    }

    void Start()
    {
        
        //Enter game sounds
        EnterGameSound = gameObject.AddComponent<AudioSource>();
        EnterGameSound.clip = EnterGameClip;
        EnterGameSound.loop = true;         //set loops
        EnterGameSound.volume = 0.6f;       //set volume
        EnterGameSound.pitch = 0.8f;        //set pitch
        EnterGameSound.Play();              //play the sound

        //Background sounds
        BackgroundSound = gameObject.AddComponent<AudioSource>();
        BackgroundSound.clip = BackgroundClip;
        BackgroundSound.loop = true;        //set loops
        BackgroundSound.volume = 0.5f;      //set volume
        BackgroundSound.pitch = 0.7f;       //set pitch
        BackgroundSound.Stop();             //stop the sound

        //Game Over sound
        GameoverSound = gameObject.AddComponent<AudioSource>();
        GameoverSound.clip = GameoverClip;
        GameoverSound.Stop();               //stop the sound

    }

    // Update is called once per frame
    void Update()
    {
        //press any key to start game
        if (IsPlaying() == false && Input.anyKey)
        {
            GameStart();        //start game
        }

        //transform the sound when player dead
        if (character.GetComponent<PlayerHealth>().isAlive == false&&!GameoverSound.isPlaying&&BackgroundSound.isPlaying)
        {
            BackgroundSound.Stop();
            GameoverSound.Play();
        }
    }

    /* Start game */
    void GameStart()
    {
        Time.timeScale = 1;         // exit pause game
        title.SetActive(false);     // turn off the title
        EnterGameSound.Stop();      // stop enter game sound
        BackgroundSound.Play();     // play the background sound 
    }

    /* Game over */
    public void GameOver()
    {
        // save highScore
        FindObjectOfType<Score>().save();

        // turn on the Title
        title.SetActive(true);

        //turn on gameover menu
        gameovermenu.SetActive(true);
        title.SetActive(false);
    }

    /* Check if player is playing or not */
    public bool IsPlaying()
    {
        return title.activeSelf == false;
    }
}
