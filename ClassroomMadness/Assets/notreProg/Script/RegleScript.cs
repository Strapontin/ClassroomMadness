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

    bool hasdmgPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        rightHand = GameObject.Find("LeftHand");
        leftHand = GameObject.Find("RightHand");
        PlayerPrefs.SetInt("RuleHastouchplayer", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
        {
            timeAlivebeforeRespaw -= 2 * Time.deltaTime;
        }
        else
        {
            timeAlivebeforeRespaw = 2;
        }
        if(timeAlivebeforeRespaw <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Stud"))
        {
            rightHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
            leftHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
            if(collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(destunWait());
                hasdmgPlayer = true;
                GameObject.Find("InstancierEleves").GetComponent<InstancierEleves>().spawnStudent();
            }
            if(hasdmgPlayer == true)
            {
                hasdmgPlayer = false;
                destroyAllBullet();
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
                StartCoroutine(destunWait());
                destroyAllBullet();
                GameObject.Find("InstancierEleves").GetComponent<InstancierEleves>().spawnStudent();
                print("collison eleve joeur");
            }
            Destroy(gameObject);
        }


    }

    IEnumerator destunWait()
    {
        yield return new WaitForSeconds(2.5f);
        PlayerPrefs.SetInt("RuleHastouchplayer", 1);
    }


    void destroyAllBullet()
    {
        GameObject[] f;
        f = GameObject.FindGameObjectsWithTag("boulette");
        foreach (GameObject food in f)
        {
            Destroy(food);
        }
    }
}
