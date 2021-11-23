using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitPanelUI : MonoBehaviour
{
	static WaitPanelUI instance;

	// Start is called before the first frame update
	void Start()
    {
		Invoke("OnBackPressed", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public static WaitPanelUI ShowUI()
	{

		if (instance == null)
		{
			GameObject obj = Instantiate(Resources.Load("PreFabs/WaitPanel")) as GameObject;
			obj.transform.SetParent(Camera.main.transform, false);
			
			instance = obj.GetComponent<WaitPanelUI>();
		}

		return instance;
	}

	public void OnBackPressed()
	{
		
		Time.timeScale = 1.5f;
		Destroy(gameObject, 0.2f);
	}

}
