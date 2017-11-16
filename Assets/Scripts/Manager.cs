﻿using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{

    public GameObject player;
    private GameObject title;

    AudioSource BackgroundSound;
    public AudioClip BackgroundClip;

    AudioSource GameoverSound;
    public AudioClip GameoverClip;

    AudioSource EnterGameSound;
    public AudioClip EnterGameClip;

    public GameObject character;

    // Use this for initialization
    void Start()
    {
        title = GameObject.Find("Title");

        //Enter game sounds
        EnterGameSound = gameObject.AddComponent<AudioSource>();
        EnterGameSound.clip = EnterGameClip;
        EnterGameSound.loop = true;
        EnterGameSound.volume = 0.6f;
        EnterGameSound.pitch = 0.8f;
        EnterGameSound.Play();

        //Background sounds
        BackgroundSound = gameObject.AddComponent<AudioSource>();
        BackgroundSound.clip = BackgroundClip;
        BackgroundSound.loop = true;
        BackgroundSound.volume = 0.5f;
        BackgroundSound.pitch = 0.7f;
        BackgroundSound.Stop();

        //Game Over sound
        GameoverSound = gameObject.AddComponent<AudioSource>();
        GameoverSound.clip = GameoverClip;
        GameoverSound.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying() == false && Input.anyKey)
        {
            GameStart();
        }
        if (character.GetComponent<PlayerHealth>().isAlive == false&&!GameoverSound.isPlaying&&BackgroundSound.isPlaying)
        {
            BackgroundSound.Stop();
            GameoverSound.Play();
        }
    }

    void GameStart()
    {
        title.SetActive(false);
        EnterGameSound.Stop();
        BackgroundSound.Play();
    }
    public void GameOver()
    {
        // lưu lại highScore
        FindObjectOfType<Score>().save();

        // hiển thị lại Title
        title.SetActive(true);
    }
    public bool IsPlaying()
    {
        return title.activeSelf == false;
    }
}
