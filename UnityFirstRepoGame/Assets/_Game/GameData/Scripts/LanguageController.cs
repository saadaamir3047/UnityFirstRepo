using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour
{
    public string english;
    public string danish;
    private void Awake()
    {
        //PlayerPrefs.SetString("language", "danish");
    }
    void Start()
    {
        if (PlayerPrefs.GetString("language", "english") == "english")
            GetComponent<Text>().text = english;
        else
            GetComponent<Text>().text = danish;
    }
    private void Update()
    {
        if (PlayerPrefs.GetString("language", "english") == "english")
            GetComponent<Text>().text = english;
        else
            GetComponent<Text>().text = danish;
    }
}
