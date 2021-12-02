using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject SoundOnBtn;
    public GameObject SoundOffBtn;
    public GameObject MusicOnBtn;
    public GameObject MusicOffBtn;
    public GameObject CorrectModeBtn;
    public GameObject WrongModeBtn;
    public Text Diamonds;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("totalDiamonds", 1000);
        
        if (PlayerPrefs.GetInt("GameMode", 0) == 0)
        {
            CorrectModeBtn.SetActive(true);
            WrongModeBtn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GameMode", 0) == 1)
        {
            CorrectModeBtn.SetActive(false);
            WrongModeBtn.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Diamonds.text = PlayerPrefs.GetInt("totalDiamonds", 200) + "";
        
        if (PlayerPrefs.GetInt("GameMode", 0) == 0)
        {
            CorrectModeBtn.SetActive(true);
            WrongModeBtn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GameMode", 0) == 1)
        {
            CorrectModeBtn.SetActive(false);
            WrongModeBtn.SetActive(true);

        }
    }

    public void openSettingsPannel()
    {
        SoundManager.instance.playBtnClickSound();
        SettingsPannelUI.ShowUI();
    }

    public void openShopPannel()
    {
        SoundManager.instance.playBtnClickSound();
        ShopPannelUI1.ShowUI();
    }

    public void openCartPannel()
    {
        SoundManager.instance.playBtnClickSound();
        CartPannelUI.ShowUI();
    }

    public void AdditionAndSubtraction()
    {
        SoundManager.instance.playBtnClickSound();
        AdditionsPannel.ShowUI();
        //PlayerPrefs.SetInt("gameType", 1);
        //SceneManager.LoadScene("SampleScene");
    }

    public void MultiplicationAndDivision()
    {
        SoundManager.instance.playBtnClickSound();
        MulDivPannel.ShowUI();
        //PlayerPrefs.SetInt("gameType", 2);
        //SceneManager.LoadScene("SampleScene");
    }

    public void Equations()
    {
        SoundManager.instance.playBtnClickSound();
        AljebricEquations.ShowUI();
        //PlayerPrefs.SetInt("gameType", 3);
        //SceneManager.LoadScene("SampleScene");
    }

    public void Conversions()
    {
        SoundManager.instance.playBtnClickSound();
        ConversionsPannel.ShowUI();
        //PlayerPrefs.SetInt("gameType", 4);
        //SceneManager.LoadScene("SampleScene");
    }

    public void DecimalOrFractionsPannel()
    {
        SoundManager.instance.playBtnClickSound();
        DecToFracPannel.ShowUI();
        //PlayerPrefs.SetInt("gameType", 4);
        //SceneManager.LoadScene("SampleScene");
    }
    
    public void DiceAddPannels()
    {
        SoundManager.instance.playBtnClickSound();
        DiceAddPannel.ShowUI();
        //PlayerPrefs.SetInt("gameType", 4);
        //SceneManager.LoadScene("SampleScene");
    }

    public void GenerateRandomQuestions()   
    {
        SoundManager.instance.playBtnClickSound();
        PlayerPrefs.SetInt("gameType", 5);
        SceneManager.LoadScene("SampleScene");
    }
    public void CorrectMode()
    {
        SoundManager.instance.playBtnClickSound();
        PlayerPrefs.SetInt("GameMode", 0);
        CorrectModeBtn.SetActive(true);
        WrongModeBtn.SetActive(false);
    }

    public void WrongMode()
    {
        SoundManager.instance.playBtnClickSound();
        PlayerPrefs.SetInt("GameMode", 1);
        CorrectModeBtn.SetActive(false);
        WrongModeBtn.SetActive(true);
    }


}
