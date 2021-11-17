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
		//this.gameObject.GetComponent<Animator>().Play("panel Animations reverse");
		//SoundManager.instance.Play_Button_Sound();
		Destroy(gameObject, 0.5f);
	}

	public void turnMusicOn()
	{
		MusicOnBtn.SetActive(false);
		MusicOffBtn.SetActive(true);
	}

	public void turnMusicOff()
	{
		MusicOnBtn.SetActive(true);
		MusicOffBtn.SetActive(false);
	}

	public void turnSoundOn()
	{
		SoundOnBtn.SetActive(false);
		SoundOffBtn.SetActive(true);
	}

	public void turnSoundOff()
	{
		SoundOnBtn.SetActive(true);
		SoundOffBtn.SetActive(false);
	}
}
