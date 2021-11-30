using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseParent : MonoBehaviour
{
    public QuestionManager QM;
    public GameManager gm;
    public Transform ChildTarget;
    public BallJump bj;
    // Start is called before the first frame update
    private void Awake()
    {
        QM = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        bj = GameObject.Find("Ball").GetComponent<BallJump>();
    }
    void Start()
    {
        
        if (!gm.DecimalToFraction)
        {
            transform.GetChild(0).GetComponent<Base>().ansText.text = QM.w.ToString();
            transform.GetChild(1).GetComponent<Base>().ansText.text = QM.x.ToString();
            transform.GetChild(2).GetComponent<Base>().ansText.text = QM.y.ToString();
            transform.GetChild(3).GetComponent<Base>().ansText.text = QM.z.ToString();
        }
        else if (gm.DecimalToFraction)
        {
            transform.GetChild(0).GetComponent<Base>().ansText.text = QM.decimalAns1;
            transform.GetChild(1).GetComponent<Base>().ansText.text = QM.decimalAns2;
            transform.GetChild(2).GetComponent<Base>().ansText.text = QM.decimalAns3;
            transform.GetChild(3).GetComponent<Base>().ansText.text = QM.decimalAns4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChildTarget = transform.GetChild(0);
        if (transform.childCount == 1)
        {
            ChildTarget = transform.GetChild(0);
            //gm.WAMove = ChildTarget;
            //bj.targetPosition = new Vector3(gm.WAMove.position.x, bj.transform.position.y, gm.WAMove.position.z);
            //bj.MoveTo();
        }
        //StartCoroutine(waitaLil());
    }

    IEnumerator waitaLil()
    {
        yield return new WaitForSeconds(0.2f);
        ChildTarget = transform.GetChild(0);
    }

    public void CanJumpFalse()
    {

    }

    public void setBoxw()
    {
        transform.GetChild(0).GetComponent<Base>().wrightAns = true;
    }
    public void setBoxx()
    {
        transform.GetChild(1).GetComponent<Base>().wrightAns = true;

    }
    public void setBoxy()
    {
        transform.GetChild(2).GetComponent<Base>().wrightAns = true;

    }
    public void setBoxz()
    {
        transform.GetChild(3).GetComponent<Base>().wrightAns = true;

    }
}
