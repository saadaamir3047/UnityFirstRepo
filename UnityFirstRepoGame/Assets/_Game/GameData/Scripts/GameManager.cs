using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject retrypanel;
    public BallJump bj;

    public bool plus = false;
    public bool multiply = false;
    public bool equation = false;
    public bool conversion = false;
    public bool all = false;

    public int score;
    public Text scoreText;
    public int HighScore;
    public Text highScoreText;


    // Start is called before the first frame update
    
    void Start()
    {
        checkType();
        score = 0;
    }

    public void checkType()
    {
        all = false;
        plus = false;
        multiply = false;
        equation = false;
        conversion = false;
        if(PlayerPrefs.GetInt("gameType", 0) == 0)
        {
            Debug.LogError("No Type was selected");
        }
        else if(PlayerPrefs.GetInt("gameType", 0) == 1)
        {
            plus = true;
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 2)
        {
            multiply = true;
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 3)
        {
            equation = true;

        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 4)
        {
            conversion = true;
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 5)
        {
            //All Stands for Random Questions.
            all = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if (PlayerPrefs.GetInt("HighScore", 0) < score)
            PlayerPrefs.SetInt("HighScore", score);
    }

    public void retry()
    {
        SoundManager.instance.playBtnClickSound();
        SceneManager.LoadScene("SampleScene");
        retrypanel.SetActive(false);
    }

    public void gameover()
    {
        bj.isDead = true;
        retrypanel.SetActive(true);
    }

    public void openPausePannel()
    {
        SoundManager.instance.playBtnClickSound();
        PausePannel.ShowUI();
        Time.timeScale = 0;
    }

}
