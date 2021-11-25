using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceAddPannel : MonoBehaviour
{
	static DiceAddPannel instance;

	void Start()
	{
        
    }

	public static DiceAddPannel ShowUI()
	{
		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/DiceAddPannel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<DiceAddPannel>();
		}
		return instance;
	}

	public void OnBackPressed()
	{
		SoundManager.instance.playBtnClickSound();
		Time.timeScale = 1.5f;

		Destroy(gameObject, 0.2f);
	}

	public void TwoDice()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 26);
		SceneManager.LoadScene("SampleScene");
	}

	public void ThreeDice()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 27);
		SceneManager.LoadScene("SampleScene");
	}

	public void MixDices()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 28);
		SceneManager.LoadScene("SampleScene");
	}

}
