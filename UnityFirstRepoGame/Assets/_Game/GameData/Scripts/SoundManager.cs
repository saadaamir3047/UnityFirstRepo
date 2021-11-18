using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgMusic;
    public AudioSource[] allEffects;
    public bool canPlayMusic;
    public bool canPlaySound;

    public static SoundManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            disabeSound();
            canPlaySound = false;
        }
        else
        {
            canPlaySound = true;
        }

        if (PlayerPrefs.GetInt("Music", 0) == 1)
        {
            disableMusic();
            canPlayMusic = false;
        }
        else
        {
            canPlayMusic = true;
        }


    }
    public void playBtnClickSound()
    {
        allEffects[1].Play();
    }
    public void disableMusic()
    {
        bgMusic.Stop();
    }
    public void EnableeMusic()
    {
        bgMusic.Play();
    }
    public void disabeSound()
    {
        foreach(AudioSource audio in allEffects)
        {
            audio.Stop();
        }
    }

    public void enableSound()
    {
        foreach (AudioSource audio in allEffects)
        {
            audio.Play();
        }
    }

}