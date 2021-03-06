using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WABallJump : MonoBehaviour
{
    public float velocity = 13f;
    float maxVelocity = 30f;
    float minVelocity = 17f;
    public float timeThreshHold;
    public float increaseVelocity = 0;

    public float MovementSpeed;
    private Rigidbody rb;

    public bool IsBallMovingUP = false;
    public bool IsGrounded = false;

    public float oldPos;

    public Animator anim;

    public bool isDead = false;

    public Vector3 targetPosition;
    public AudioSource jump;
    public AudioSource bad;
    public int skinIndex;
    public bool movementPermission = false;
    public bool movementPermission2 = false;

    public GameObject splashParticleEffect;
    public Color[] ParticleColors;
    public bool theCorrectAnswer = false;

    public bool deadOneTime = true;

    // Start is called before the first frame update
    void Start()
    {
        enableTheSkin();
        rb = GetComponent<Rigidbody>();
        deadOneTime = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((IsGrounded)&&(!isDead))
        {
            if(velocity > maxVelocity)
            {
                velocity = maxVelocity;
            }
            rb.velocity = Vector3.up * velocity;
        }
    }

    IEnumerator delay3micsec()
    {
        yield return new WaitForSeconds(0.3f);
        if (movementPermission)
        {
            movementPermission2 = true;
        }
        else
        {
            movementPermission2 = false;
        }
    }

    private void Update()
    {
        if ((oldPos < transform.position.y) && (!isDead))
        {
            IsBallMovingUP = true;
            if (movementPermission)
            {
                StartCoroutine(delay3micsec());
            }
        }

        if ((oldPos > transform.position.y) && (!isDead))
        {
            IsBallMovingUP = false;
        }
        oldPos = transform.position.y;
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag == "ground") && (!isDead))
        {
            IsGrounded = true;
            GameObject temp =  Instantiate(splashParticleEffect, transform.position, Quaternion.identity);
            var temp2 =  temp.GetComponent<ParticleSystem>().main;
            temp2.startColor = ParticleColors[PlayerPrefs.GetInt("skinEquiped", 0)];
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.tag == "ground") && (!isDead))
        {
            IsGrounded = false;
            jump.Play();
            if (theCorrectAnswer)
            {
                theCorrectAnswer = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead && other.gameObject.tag == "ground")
        {
            //bad.Play();
            //SoundManager.instance.playDeathSound();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Diamond" && !isDead)
        {
            Destroy(other.gameObject);            
            SoundManager.instance.allEffects[4].Play();
            PlayerPrefs.SetInt("totalDiamonds", PlayerPrefs.GetInt("totalDiamonds", 200)+1);
        }

        if (isDead && other.gameObject.tag == "ground")
        {
            if (deadOneTime)
            {
                SoundManager.instance.playDeathSound();
                print("Death Sound played!");
            }
            anim.SetBool("Dead", true);
            SoundManager.instance.bgMusic.Stop();
            deadOneTime = false;
        }
        if ((other.gameObject.tag == "ground") && (!isDead))
        {
            anim.SetBool("Jump", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "ground") && (!isDead))
        {
            anim.SetBool("Jump", false);
        }
    }

    IEnumerator waitmove()
    {
        Vector2 player2dpos = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetpos = new Vector2(targetPosition.x, targetPosition.z);

        yield return new WaitForEndOfFrame();
        while (0.1f < Mathf.Abs(Vector2.Distance(player2dpos, targetpos)))
        {
            yield return new WaitForFixedUpdate();
            if ((movementPermission && movementPermission2)) //|| isDead)
            {
                player2dpos = new Vector2(transform.position.x, transform.position.z);
                targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, MovementSpeed);
            }
        }
    }

    public void MoveTo()
    {
        StartCoroutine(waitmove());
    }

    public void enableTheSkin()
    {
        skinIndex = PlayerPrefs.GetInt("skinEquiped", 0);
        transform.GetChild(0).transform.GetChild(skinIndex).gameObject.SetActive(true);
    }
}
