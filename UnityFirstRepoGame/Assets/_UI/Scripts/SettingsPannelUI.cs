using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPannelUI : MonoBehaviour
{
	static SettingsPannelUI instance;

	public GameObject SoundOnBtn;
	public GameObject SoundOffBtn;
	public GameObject MusicOnBtn;
	public GameObject MusicOffBtn;

	void Start()
	{
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            SoundOnBtn.SetActive(false);
            SoundOffBtn.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Sound", 0) == 0)
        {
            SoundOnBtn.SetActive(true);
            SoundOffBtn.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Music", 0) == 1)
        {
            MusicOnBtn.SetActive(false);
            MusicOffBtn.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Music", 0) == 0)
        {
            MusicOnBtn.SetActive(true);
            MusicOffBtn.SetActive(false);

        }
    }

	public static SettingsPannelUI ShowUI()
	{

		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/SettingsPannel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<SettingsPannelUI>();
		}

		return instance;
	}

	public void OnBackPressed()
	{
		SoundManager.instance.playBtnClickSound();
		Time.timeScale = 1.5f;
		//this.gameObject.GetComponent<Animator>().Play("panel Animations reverse");
		//SoundManager.instance.Play_Button_Sound();
		Destroy(gameObject, 0.2f);
	}

	public void turnMusicOn()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("Music", 1);
		MusicOnBtn.SetActive(false);
		MusicOffBtn.SetActive(true);
	}

	public void turnMusicOff()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("Music", 0);
		MusicOnBtn.SetActive(true);
		MusicOffBtn.SetActive(false);
		SoundManager.instance.bgMusic.Play();
	}

	public void turnSoundOn()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("Sound", 1);
		SoundOnBtn.SetActive(false);
		SoundOffBtn.SetActive(true);
	}

	public void turnSoundOff()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("Sound", 0);
		SoundOnBtn.SetActive(true);
		SoundOffBtn.SetActive(false);
	}
}
