using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RegleScript : MonoBehaviour
{
    private GameObject rightHand;
    private GameObject leftHand;
    public float timeAlivebeforeRespaw = 2;
    bool isGrounded = false;

    private InstancierEleves InstancierEleves;


    // Start is called before the first frame update
    void Start()
    {
        rightHand = GameObject.Find("LeftHand");
        leftHand = GameObject.Find("RightHand");
        PlayerPrefs.SetInt("RuleHastouchplayer", 0);

        InstancierEleves = GameObject.Find("InstancierEleves").GetComponent<InstancierEleves>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            timeAlivebeforeRespaw -= 2 * Time.deltaTime;
        }
        else
        {
            timeAlivebeforeRespaw = 2;
        }
        if (timeAlivebeforeRespaw <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Stud"))
        {
            rightHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
            leftHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);

            if (collision.gameObject.CompareTag("Player"))
            {
                InstancierEleves.StudentGotStunned();
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Stud"))
        {
            rightHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
            leftHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);

            if (collision.gameObject.CompareTag("Player"))
            {
                InstancierEleves.StudentGotStunned();
            }
            Destroy(gameObject);
        }
    }
}
