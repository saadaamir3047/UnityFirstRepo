using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditionsPannel : MonoBehaviour
{
	static AdditionsPannel instance;

	void Start()
	{
        
    }

	public static AdditionsPannel ShowUI()
	{

		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/AdditionsPannel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<AdditionsPannel>();
		}
		return instance;
	}

	public void OnBackPressed()
	{
		SoundManager.instance.playBtnClickSound();
		Time.timeScale = 1.5f;

		Destroy(gameObject, 0.2f);
	}

	public void AddEasy()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 6);
		SceneManager.LoadScene("SampleScene");
	}

	public void addMedium()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 7);
		SceneManager.LoadScene("SampleScene");
	}

	public void addHard()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 8);
		SceneManager.LoadScene("SampleScene");
	}

	public void SubEasy()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 9);
		SceneManager.LoadScene("SampleScene");
	}

	public void SubHard()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 10);
		SceneManager.LoadScene("SampleScene");
	}

	public void AddAll()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 1);
		SceneManager.LoadScene("SampleScene");
	}


}
