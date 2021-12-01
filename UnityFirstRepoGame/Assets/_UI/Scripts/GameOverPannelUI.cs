using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPannelUI : MonoBehaviour
{
	static GameOverPannelUI instance;
	public int HighScore;
	public Text highScoreText;


	void Start()
	{
		SetStats();
	}


	public static GameOverPannelUI ShowUI()
	{
		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/ReplayPanel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<GameOverPannelUI>();
		}
		return instance;
	}

	public void OnBackPressed()
	{
		SoundManager.instance.playBtnClickSound();
		//this.gameObject.GetComponent<Animator>().Play("panel Animations reverse");
		//SoundManager.instance.Play_Button_Sound();
		Destroy(gameObject, 0.1f);
	}

	public void goToMainMenu()
	{
		SoundManager.instance.playBtnClickSound();
		SceneManager.LoadScene("MenuScene");
		Time.timeScale = 1.5f;
	}
	public void retry()
	{
		SoundManager.instance.playBtnClickSound();
		SceneManager.LoadScene("SampleScene");
		OnBackPressed();
		//retrypanel.SetActive(false);
	}

	public void SetStats()
    {
		HighScore = PlayerPrefs.GetInt("HighScore", 0);
		if (PlayerPrefs.GetString("language", "english") == "english")
			highScoreText.text = "HighScore: " + HighScore;
		else
			highScoreText.text = "Højeste Score: " + HighScore;

	}
}
