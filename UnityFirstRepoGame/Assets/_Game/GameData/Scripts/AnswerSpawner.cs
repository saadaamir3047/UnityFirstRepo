using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSpawner : MonoBehaviour
{

    public static AnswerSpawner instance;
    public GameObject BaseAnswer;
    public GameObject Diamond;
    GameObject go;
    GameObject Dimo;
    public Queue<GameObject> GoQue;
    public int StepsCount = 0;
    public GameManager gm;
    public BallJump bj;
    public Transform WATransform;
    public CamMove cm;
    private void Awake()
    {
        bj = GameObject.Find("Ball").GetComponent<BallJump>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        cm = GameObject.Find("Main Camera").GetComponent<CamMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StepsCount = 0;
        instance = this;

        go = Instantiate(BaseAnswer, new Vector3(0f, -7.3f, 0), Quaternion.identity);
        QuestionManager.instance.BP = go.GetComponent<BaseParent>();
        GoQue = new Queue<GameObject>();
        GoQue.Enqueue(go);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newAns(Transform t)
    {
        go = Instantiate(BaseAnswer, new Vector3(0f, t.position.y - 1.5f, t.position.z - 2), Quaternion.identity);
        QuestionManager.instance.BP = go.GetComponent<BaseParent>();
        GoQue.Enqueue(go);
        StepsCount++;
        if(StepsCount == 4)
        {
            Transform newPos = t;
            for(int i=0; i<4; i++)
            {
                newPos = t.transform.GetChild(i).transform;
                Dimo = Instantiate(Diamond, new Vector3(newPos.position.x, newPos.position.y, newPos.position.z - 2), Quaternion.identity);
            }
            StepsCount = -1;
        }
        WATransform = t;
        StartCoroutine(WAwait());
        //bj.MoveTo();
    }
    IEnumerator WAwait()
    {
        yield return new WaitForSeconds(0.2f);
        gm.WAMove = WATransform.GetComponent<BaseParent>().ChildTarget;
        bj.targetPosition = new Vector3(gm.WAMove.position.x, bj.transform.position.y, gm.WAMove.position.z);
        bj.MoveTo();
    }


    public void delBox()
    {
        if (GoQue.Count == 11)
        {
            Destroy(GoQue.Dequeue());
        }
    }
    public void DisableJump()
    {
        int childlength = go.transform.childCount;
        for (int i = 0; i < childlength; i++)
        {
            go.transform.GetChild(i).GetComponent<Base>().canJump = false;
        }
    }
}
