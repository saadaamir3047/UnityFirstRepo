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
    public Text Diamonds;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("totalDiamonds", 1000);
    }

    // Update is called once per frame
    void Update()
    {
        Diamonds.text = PlayerPrefs.GetInt("totalDiamonds", 200) + "";
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

    public void GenerateRandomQuestions()   
    {
        SoundManager.instance.playBtnClickSound();
        PlayerPrefs.SetInt("gameType", 5);
        SceneManager.LoadScene("SampleScene");
    }

    

}
