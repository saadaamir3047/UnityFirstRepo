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
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                if (SoundManager.instance.canPlaySound)
                    good.Play();
            }

            if (wrightAns != true)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                //bj.isDead = true;
                StartCoroutine(waitAndDie());
                StartCoroutine(waitForRetryPannel());
            }
        }
    }
    IEnumerator waitForRetryPannel()
    {
        yield return new WaitForSeconds(2f);
        GameOverPannelUI.ShowUI();
    }

    IEnumerator waitAndDie()
    {
        yield return new WaitForSeconds(1f);
        bj.isDead = true;
    }

}

