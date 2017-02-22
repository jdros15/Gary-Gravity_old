using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class highScore : MonoBehaviour {

    Text scoreText,hscoreText,txtScore;
    int score, hscore;
	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        hscoreText = GameObject.Find("txtHs").GetComponent<Text>();
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckAndSet()
    {
        score = int.Parse(scoreText.text);
        if (PlayerPrefs.HasKey("Highscore"))
        {
          
            hscore = PlayerPrefs.GetInt("Highscore");

            if (score > hscore)
            {
                hscoreText.text = score.ToString();
                PlayerPrefs.SetInt("Highscore", score);
                txtScore.text = "new highscore";

                

            }
            else
            {
                hscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
            }
        }
        else
        {

            PlayerPrefs.SetInt("Highscore", score);
            hscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }


}
