using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject retrypanel;
    public BallJump bj;

    public bool all = false;
    public bool plus = false;
    public bool multiply = false;
    public bool equation = false;
    public bool conversion = false;


    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void retry()
    {
        SceneManager.LoadScene(0);
        retrypanel.SetActive(false);

    }

    public void gameover()
    {
        bj.isDead = true;
        retrypanel.SetActive(true);
    }

}
