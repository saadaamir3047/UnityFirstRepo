using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePannel : MonoBehaviour
{
	static PausePannel instance;
	public GameObject ResumeBtn;
	public GameObject MainMenuBtn;
	public GameObject SettingsBtn;

	void Start()
	{

	}

	public static PausePannel ShowUI()
	{

		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/PausePannel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<PausePannel>();
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

	public void goToMainMenu()
    {
		SoundManager.instance.playBtnClickSound();
		SceneManager.LoadScene("MenuScene");
		Time.timeScale = 1.5f;
	}

	public void GoToSettingsMenu()
    {
		SoundManager.instance.playBtnClickSound();
		SettingsPannelUI.ShowUI();
		Destroy(gameObject, 0.2f);
	}

}
