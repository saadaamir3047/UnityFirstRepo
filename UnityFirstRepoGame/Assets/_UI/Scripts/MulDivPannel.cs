using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MulDivPannel : MonoBehaviour
{
	static MulDivPannel instance;

	void Start()
	{
        
    }

	public static MulDivPannel ShowUI()
	{

		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/MulDivPannel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<MulDivPannel>();
		}
		return instance;
	}

	public void OnBackPressed()
	{
		SoundManager.instance.playBtnClickSound();
		Time.timeScale = 1.5f;

		Destroy(gameObject, 0.2f);
	}

	public void mulEasy()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 11);
		SceneManager.LoadScene("SampleScene");
	}

	public void mulHard()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 12);
		SceneManager.LoadScene("SampleScene");
	}

	public void divEasy()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 13);
		SceneManager.LoadScene("SampleScene");
	}

	public void divHard()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 14);
		SceneManager.LoadScene("SampleScene");
	}

	public void mulDivAll()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 2);
		SceneManager.LoadScene("SampleScene");
	}


}
