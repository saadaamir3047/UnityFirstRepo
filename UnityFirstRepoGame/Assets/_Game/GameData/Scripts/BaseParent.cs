using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseParent : MonoBehaviour
{
    public QuestionManager QM;
    // Start is called before the first frame update
    private void Awake()
    {
        QM = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();
    }
    void Start()
    {
        transform.GetChild(0).GetComponent<Base>().ansText.text = QM.w.ToString();
        transform.GetChild(1).GetComponent<Base>().ansText.text = QM.x.ToString();
        transform.GetChild(2).GetComponent<Base>().ansText.text = QM.y.ToString();
        transform.GetChild(3).GetComponent<Base>().ansText.text = QM.z.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
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
