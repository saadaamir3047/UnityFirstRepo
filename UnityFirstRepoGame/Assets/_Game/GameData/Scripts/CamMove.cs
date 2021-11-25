using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 Campos;
    public BallJump bj;
    // Start is called before the first frame update


    void Start()
    {
        
    }
    private void Awake()
    {
        bj = GameObject.Find("Ball").GetComponent<BallJump>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPos()
    {
        StartCoroutine(cammove());
    }

    IEnumerator cammove()
    {
        targetPosition =new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z - 2f);

        yield return new WaitForEndOfFrame();
        while (0.05f < Mathf.Abs(Vector3.Distance(Campos, targetPosition)))
        {
            
            yield return new WaitForEndOfFrame();            
            Campos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(Campos, targetPosition, 0.05f);
            //bj.movementPermission2 = true;
            bj.movementPermission = true;
        }
    }
}


