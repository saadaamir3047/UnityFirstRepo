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
    
    public bool addEasy;
    public bool addMedium;
    public bool addHard;
    public bool SubEasy;
    public bool SubHard;

    public bool mulEasy;
    public bool mulHard;
    public bool divEasy;
    public bool divHard;

    public bool kg;
    public bool meter;
    public bool metersq;
    public bool centiMeter;
    public bool miliLiters;

    public bool dbms;
    public bool roots;
    public bool simpleEq;

    public bool fractionToDecimal;
    public bool DecimalToFraction;
    public bool DecimalOrFractionBoth;
    
    public bool TwoDices;
    public bool ThreeDices;
    public bool MixDices;



    public int score;
    public Text scoreText;
    public int HighScore;
    public Text highScoreText;
    public int DiamondsNumber;
    public Text Diamonds;


    // Start is called before the first frame update
    
    void Start()
    {
        checkType();
        score = 0;
        Application.targetFrameRate = 30;
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
        else if (PlayerPrefs.GetInt("gameType", 0) == 6)
        {
            addEasy = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 7)
        {
            addMedium = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 8)
        {
            addHard = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 9)
        {
            SubEasy = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 10)
        {
            SubHard = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 11)
        {
            mulEasy = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 12)
        {
            mulHard = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 13)
        {
            divEasy = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 14)
        {
            divHard = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 15)
        {
            kg = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 16)
        {
            meter = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 17)
        {
            metersq = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 18)
        {
            centiMeter = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 19)
        {
            miliLiters = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 20)
        {
            dbms = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 21)
        {
            roots = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 22)
        {
            simpleEq = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 23)
        {
            fractionToDecimal = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 24)
        {
            DecimalToFraction = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 25)
        {
            DecimalOrFractionBoth = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 26)
        {
            TwoDices = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 27)
        {
            ThreeDices = true;
            //All Stands for Random Questions.
        }
        else if (PlayerPrefs.GetInt("gameType", 0) == 28)
        {
            MixDices = true;
            //All Stands for Random Questions.
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if (PlayerPrefs.GetInt("HighScore", 0) < score)
            PlayerPrefs.SetInt("HighScore", score);
        Diamonds.text = PlayerPrefs.GetInt("totalDiamonds", 100) + "";
    }

    public void retry()
    {
        SoundManager.instance.playBtnClickSound();
        SceneManager.LoadScene("SampleScene");
        //StartCoroutine(waitForRetryPannel());
        retrypanel.SetActive(false);
    }

    public void gameover()
    {
        //bj.isDead = true;
        retrypanel.SetActive(true);
        //StartCoroutine(waitForRetryPannel());
    }
    IEnumerator waitForRetryPannel()
    {
        yield return new WaitForSeconds(2f);
        retrypanel.SetActive(true);
    }

    public void openPausePannel()
    {
        SoundManager.instance.playBtnClickSound();
        PausePannel.ShowUI();
        Time.timeScale = 0;
    }

}
