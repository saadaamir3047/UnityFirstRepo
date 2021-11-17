using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgMusic;
    public AudioSource[] allEffects;

    public static SoundManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playBtnClickSound()
    {
        allEffects[1].Play();
    }
}