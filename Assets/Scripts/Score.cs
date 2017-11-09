﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public Text scoreGUIText;
    public Text highscoreGUIText;
    private int score;
    private int highScore;
    private string highscoreKey = "highScore";

	// Use this for initialization
	void Start () {
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        if (highScore < score) highScore = score;
        scoreGUIText.text = "Score : "+ score.ToString();
        highscoreGUIText.text = "High Score : " + highScore.ToString();

	}
    private void Initialize()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(highscoreKey, 0);
    }
    public void AddPoint(int point)
    {
        score += point;
    }
    public void save()
    {
        PlayerPrefs.SetInt(highscoreKey, highScore);
        PlayerPrefs.Save();
        Initialize();
    }
}