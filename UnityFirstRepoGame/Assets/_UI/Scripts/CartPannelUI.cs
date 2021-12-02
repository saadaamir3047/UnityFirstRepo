using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartPannelUI : MonoBehaviour
{
	static CartPannelUI instance;
	public Text diomandCoins;
	public Text[] ballText;
	

	void Start()
	{

	}

    private void Update()
    {
		diomandCoins.text = PlayerPrefs.GetInt("totalDiamonds", 200) + "";
		for(int i=1; i<19; i++)
        {
			if (PlayerPrefs.GetInt("skinBought" + i, 0) == 1)
			{
				if (PlayerPrefs.GetString("language", "english") == "english")
				{
					ballText[i-1].text = "Bought";
				}
				else if (PlayerPrefs.GetString("language", "english") == "danish")
				{
					ballText[i - 1].text = "Købt";
				}
				if(PlayerPrefs.GetInt("skinEquiped", 0) == i)
                {
					if (PlayerPrefs.GetString("language", "english") == "english")
					{
						ballText[i - 1].text = "equiped";
					}
					else if (PlayerPrefs.GetString("language", "english") == "danish")
					{
						ballText[i - 1].text = "udstyret";
					}
					ballText[i - 1].transform.parent.transform.gameObject.GetComponent<Image>().color = new Color32(144, 238, 144, 255);
				}
				ballText[i - 1].transform.parent.transform.GetChild(0).gameObject.SetActive(false);

			}
		}
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
        if (PlayerPrefs.GetInt("totalDiamonds", 200) >= 100 && PlayerPrefs.GetInt("skinBought"+index, 0) == 0)
        {
			PlayerPrefs.SetInt("skinBought"+index, 1);
			PlayerPrefs.SetInt("totalDiamonds", PlayerPrefs.GetInt("totalDiamonds", 200) - 100);
		}

		if(PlayerPrefs.GetInt("skinBought"+index, 0) == 1)
        {
			PlayerPrefs.SetInt("skinEquiped", index);
        }
		OnBackPressed();
    }

}
