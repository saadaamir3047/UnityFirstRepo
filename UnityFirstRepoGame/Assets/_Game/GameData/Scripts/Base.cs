using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    //BallJump balljumpscrit = GetComponent<BallJump>();
    //player = GameObject.Find("Player").GetComponent<Player>(); in awake
    
    public BallJump bj;
    public CamMove cm;
    public AnswerSpawner AS;
    public bool canJump = true;
    public QuestionManager QM;
    public Text ansText;
    public bool wrightAns = false;
    public GameObject retrypanel;
    public AudioSource good;
    public AudioSource bad;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        bj = GameObject.Find("Ball").GetComponent<BallJump>();
        cm = GameObject.Find("Main Camera").GetComponent<CamMove>();
        AS = GameObject.Find("AnswerSpawner").GetComponent<AnswerSpawner>();
        QM = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();
        retrypanel = GameObject.Find("GameManager").GetComponent<GameManager>().retrypanel;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            

    }
    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnMouseDown()
    {
        if (canJump)
        {
        AS.DisableJump();
        bj.targetPosition =new Vector3(transform.position.x , bj.transform.position.y , transform.position.z);
        bj.MoveTo();
            if (!bj.isDead && wrightAns)
            {
                bj.MoveTo();
                AnswerSpawner.instance.newAns(transform.parent);
                cm.NewPos();

                AnswerSpawner.instance.delBox();

                //QM.count++;
                QM.slider.GetComponent<Slider>().value = 0;
                //print(QM.count);
                if (gm.all)
                {
                    QM.nextAns();
                }
                if (gm.multiply)
                {
                    QM.dividemultiply();

                }
                if (gm.equation)
                {
                    QM.equation();

                }
                if (gm.conversion)
                {
                    QM.conversion();
                }
                if (gm.plus)
                {
                    QM.additionsubs();

                }
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                if(SoundManager.instance.canPlaySound)
                    good.Play();
            }
        
            if (wrightAns !=true)

            {
                bj.MoveTo();
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                bj.isDead = true;
                retrypanel.SetActive(true);
                //bj.anim.SetBool("Dead", true);
            }
            
        }
    }
}

