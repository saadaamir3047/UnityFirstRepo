using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPannelUI : MonoBehaviour
{
	static CartPannelUI instance;


	void Start()
	{

	}


	public static CartPannelUI ShowUI()
	{

		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/CartPannel")) as GameObject;
			Canvas[] cans = GameObject.FindObjectsOfType<Canvas>() as Canvas[];
			for (int i = 0; i < cans.Length; i++)
			{
				if (cans[i].gameObject.activeInHierarchy && cans[i].gameObject.tag.Equals("mainCanvas"))
				{
					obj.transform.SetParent(cans[i].transform, false);
					break;
				}
			}
			instance = obj.GetComponent<CartPannelUI>();
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

	public void BuySkins(int index)
    {
		//Skin Bought 0 means not bought and 1 means the skin is bought
        if (PlayerPrefs.GetInt("totalDiamonds", 100) >= 100 && PlayerPrefs.GetInt("skinBought", 0) == 0)
        {
			PlayerPrefs.SetInt("skinBought", 1);
			PlayerPrefs.SetInt("totalDiamonds", PlayerPrefs.GetInt("totalDiamonds", 100) - 100);
		}

		if(PlayerPrefs.GetInt("skinBought", 0) == 1)
        {
			PlayerPrefs.SetInt("skinEquiped", index);
        }
		OnBackPressed();
    }

}
