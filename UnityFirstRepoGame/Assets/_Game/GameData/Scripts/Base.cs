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
    public Color myColor;
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

    IEnumerator wait2Sec()
    {
        yield return new WaitForSeconds(2f);
        bj.movementPermission = false;
        bj.movementPermission2 = false;
     }

    private void OnMouseDown()
    {
        if (canJump)
        {
            
            AS.DisableJump();
            WaitPanelUI.ShowUI();
            bj.theCorrectAnswer = true;
            bj.movementPermission = true;
            StartCoroutine(wait2Sec());
            bj.targetPosition = new Vector3(transform.position.x, bj.transform.position.y, transform.position.z);
            bj.MoveTo();
            if (!bj.isDead && wrightAns)
            {
                QM.slider2.SetActive(true);
                Debug.Log("You Answered in" + QM.TimeToAnswer);
                QM.slider2.GetComponent<Slider>().value = bj.timeThreshHold;
                if (QM.TimeToAnswer < bj.timeThreshHold)
                {
                    bj.increaseVelocity += 2.0f;
                    bj.velocity += bj.increaseVelocity;
                }
                else if(QM.TimeToAnswer > bj.timeThreshHold)
                {
                    bj.velocity = 17.0f;
                }
                QM.TimeToAnswer = 0f;



                StartCoroutine(waitForBlueColor());
                gm.score++;
                AnswerSpawner.instance.newAns(transform.parent);
                cm.NewPos();

                AnswerSpawner.instance.delBox();

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
                if (gm.addEasy)
                {
                    QM.add2number1to10();
                    //QM.DecToFraction();
                }
                if (gm.addMedium)
                {
                    QM.add2numbert20to100();
                    //QM.FractionToDec();
                }
                if (gm.addHard)
                {
                    QM.add2numbert100to1000();
                }
                if (gm.SubEasy)
                {
                    QM.subs2number1to10();
                }
                if (gm.SubHard)
                {
                    QM.subs2numbert1to100();
                }
                if (gm.mulEasy)
                {
                    QM.multiplcation2number2to10();
                }
                if (gm.mulHard)
                {
                    QM.multiplcation2number2to10and10to20();
                }
                if (gm.divEasy)
                {
                    QM.division2to50();
                }
                if (gm.divHard)
                {
                    QM.division2to100();
                }
                if (gm.kg)
                {
                    QM.kgconversion();
                }
                if (gm.meter)
                {
                    QM.mconversion();
                }
                if (gm.metersq)
                {
                    QM.m2conversion();
                }
                if (gm.centiMeter)
                {
                    QM.cm3conversion();
                }
                if (gm.miliLiters)
                {
                    QM.mlconversion();
                }
                if (gm.dbms)
                {
                    QM.dmas();
                }
                if (gm.roots)
                {
                    QM.roots();
                }
                if (gm.simpleEq)
                {
                    QM.simpleequation();
                }
                if (gm.fractionToDecimal)
                {
                    QM.FractionToDec();
                }
                if (gm.DecimalToFraction)
                {
                    QM.DecToFraction();
                }
                if (gm.DecimalOrFractionBoth)
                {
                    QM.DecimalFractionBoth();
                }
                if (gm.TwoDices)
                {
                    QM.DiceTwo();
                }
                if (gm.ThreeDices)
                {
                    QM.DiceThree();
                }
                if (gm.MixDices)
                {
                    QM.MixDices();
                }
                if (SoundManager.instance.canPlaySound)
                    good.Play();
                //gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }

            if (wrightAns != true)
            {
                StartCoroutine(waitForRedColor());
                //gameObject.GetComponent<Renderer>().material.color = Color.red;
                //bj.isDead = true;
                StartCoroutine(waitAndDie());
                StartCoroutine(waitForRetryPannel());
            }
        }
    }

    IEnumerator waitForBlueColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Renderer>().material.color = myColor;
        yield return new WaitForSeconds(0.85f);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    IEnumerator waitForRedColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Renderer>().material.color = myColor;
        yield return new WaitForSeconds(0.85f);
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
    IEnumerator waitForRetryPannel()
    {

        yield return new WaitForSeconds(2f);
        GameOverPannelUI.ShowUI();
    }

    IEnumerator waitAndDie()
    {
        yield return new WaitForSeconds(0.5f);
        bj.isDead = true;
   //     SoundManager.instance.playDeathSound();
    }

}

