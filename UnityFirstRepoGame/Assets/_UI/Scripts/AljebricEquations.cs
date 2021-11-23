using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AljebricEquations : MonoBehaviour
{
	static AljebricEquations instance;

	void Start()
	{
        
    }

	public static AljebricEquations ShowUI()
	{

		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/AljebricEquations")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<AljebricEquations>();
		}
		return instance;
	}

	public void OnBackPressed()
	{
		SoundManager.instance.playBtnClickSound();
		Time.timeScale = 1.5f;

		Destroy(gameObject, 0.2f);
	}

	public void dbms()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 20);
		SceneManager.LoadScene("SampleScene");
	}

	public void roots()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 21);
		SceneManager.LoadScene("SampleScene");
	}

	public void simpleEq()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 22);
		SceneManager.LoadScene("SampleScene");
	}

	public void AlgebricEqAll()
	{
		SoundManager.instance.playBtnClickSound();
		PlayerPrefs.SetInt("gameType", 3);
		SceneManager.LoadScene("SampleScene");
	}


}
