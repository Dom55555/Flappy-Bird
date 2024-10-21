using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text endScoreText;
    public TMP_Text highscoreText;
    public GameObject logo;
    public GameObject endScreen;
    public int highscore;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
    public void gameStart()
    {
        logo.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
    public void gameEnd()
    {
        endScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endScoreText.text = score.ToString();
        if (score > highscore) 
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        highscoreText.text = highscore.ToString();
    }

}
