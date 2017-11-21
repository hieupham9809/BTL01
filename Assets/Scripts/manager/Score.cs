using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public Text scoreGUIText;
    public Text highscoreGUIText;
    public Text gameWinningScore;                   //game winning score
    public Text gameoverScore;                      //game over score
    private int score;                              //your current score
    private int highScore;                          //highest score
    private string highscoreKey = "highScore";

    //Sound when adding point
    public AudioClip ping_sound;
    AudioSource ping;

	// Use this for initialization

    void Awake()
    {
        //add "ping" sound 
        ping = gameObject.AddComponent<AudioSource>();
        ping.clip = ping_sound;
        ping.Stop();                                //stop this sound
    }

	void Start () {
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        if (highScore < score) highScore = score;   //update highscore

        //show score and highscore
        scoreGUIText.text = "Score : "+ score.ToString();
        highscoreGUIText.text = "High Score : " + highScore.ToString();        
	}

    /*Initialize function */
    private void Initialize()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(highscoreKey, 0);
    }

    /*Add point function*/
    public void AddPoint(int point)
    {
        score += point;
        ping.Play();                                //play the "ping" sound
    }

    /*save highscore */
    public void save()
    {
        gameoverScore.text = score.ToString();      //show the game over score
        gameWinningScore.text = score.ToString();
        PlayerPrefs.SetInt(highscoreKey, highScore);
        PlayerPrefs.Save();                         //save score
        Initialize();
    }
}
