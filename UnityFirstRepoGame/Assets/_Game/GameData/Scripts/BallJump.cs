using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    public float velocity = 13f;
    private Rigidbody rb;

    public bool IsBallMovingUP = false;
    public bool IsGrounded = false;

    public float oldPos;

    public Animator anim;

    public bool isDead = false;

    public Vector3 targetPosition;
    public AudioSource jump;
    public AudioSource bad;

    public GameObject splashParticleEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((IsGrounded)&&(!isDead))
        {

            rb.velocity = Vector3.up * velocity;
            //IsBallMovingUP = true;

        }
       
    }
    private void Update()
    {if (Input.GetKeyDown(KeyCode.Space))
        {
            isDead = true;
            anim.SetBool("Dead", true);

        }

        if ((oldPos < transform.position.y) && (!isDead))
        {
            IsBallMovingUP = true;
            //anim.SetBool("IsBallMovingUP", false);
        }

        if ((oldPos > transform.position.y) && (!isDead))
        {
            IsBallMovingUP = false;
            //anim.SetBool("IsBallMovingUP", true);

        }

        oldPos = transform.position.y;


        
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag == "ground") && (!isDead))
        {
            IsGrounded = true;
            Instantiate(splashParticleEffect, transform.position, Quaternion.identity);
            //anim.SetBool("IsGrounded", true);
            //anim.SetBool("Jump", true);

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.tag == "ground") && (!isDead))
        {
            IsGrounded = false;
            jump.Play();
            //anim.SetBool("IsGrounded", false);
            //anim.SetBool("Jump", false);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isDead && other.gameObject.tag == "ground")
        {
            bad.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (isDead && other.gameObject.tag == "ground")
        {
            anim.SetBool("Dead", true);



        }
        if ((other.gameObject.tag == "ground") && (!isDead))
        {
            
            //anim.SetBool("IsGrounded", true);
            anim.SetBool("Jump", true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "ground") && (!isDead))
        {

            //anim.SetBool("IsGrounded", false);
            anim.SetBool("Jump", false);

        }
    }

    IEnumerator waitmove()
    {
        Vector2 player2dpos = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetpos = new Vector2(targetPosition.x, targetPosition.z);

        yield return new WaitForEndOfFrame();
        while (0.1f<Mathf.Abs(Vector2.Distance(player2dpos, targetpos)))
        {
            yield return new WaitForEndOfFrame();
            if (IsBallMovingUP || isDead)
            {


                player2dpos = new Vector2(transform.position.x, transform.position.z);               
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1f);
            }
            
        }
       
    }

    public void MoveTo()
    {
        StartCoroutine(waitmove());
    }
}
