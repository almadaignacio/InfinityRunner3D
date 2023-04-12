using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Text HighScoreText;
    public int scoreNumber;
    public Text scoreText;

    public float Timer;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "HI   " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
        scoreNumber = 0;
        scoreText = GetComponent<Text>();
        maxTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        Punctuation();

    }

    private void Punctuation()
    {
        Timer += Time.deltaTime;
        if (Timer >= maxTime)
        {
            scoreNumber++;
            scoreText.text = scoreNumber.ToString("00000");
            Timer = 0;
        }

        if (Time.timeScale == 0)
        {
            if (scoreNumber > PlayerPrefs.GetInt("highscore", 0))
            {
                PlayerPrefs.SetInt("highscore", scoreNumber);
                HighScoreText.text = "HI   " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
            }

        }
    }
}
