using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSpawner : MonoBehaviour
{

    public static AnswerSpawner instance;
    public GameObject BaseAnswer;
    GameObject go;
    public Queue<GameObject> GoQue;

    // Start is called before the first frame update
    void Start()
    {
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
