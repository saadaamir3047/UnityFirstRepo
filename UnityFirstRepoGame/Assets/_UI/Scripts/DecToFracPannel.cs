using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecToFracPannel : MonoBehaviour
{
	static DecToFracPannel instance;

	void Start()
	{
        
    }

	public static DecToFracPannel ShowUI()
	{
		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/DecToFracPannel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<DecToFracPannel>();
		}
		return instance;
	}

	public void OnBackPressed()
	{
		SoundManager.instance.playBtnClickSound();
		Time.timeScale = 1.5f;

		Destroy(gameObject, 0.2f);
	}

	public void Decimals()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 23);
		SceneManager.LoadScene("SampleScene");
	}

	public void Fractions()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 24);
		SceneManager.LoadScene("SampleScene");
	}

	public void DecimalsFractionsBoth()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 25);
		SceneManager.LoadScene("SampleScene");
	}

}
