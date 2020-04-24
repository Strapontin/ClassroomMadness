using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RegleScript : MonoBehaviour
{
    private GameObject rightHand;
    private GameObject leftHand;


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

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Stud"))
    //    {
    //        rightHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
    //        leftHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
    //        PlayerPrefs.SetInt("RuleHastouchplayer", 1);
    //        Destroy(gameObject);
    //    }

    //}

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Stud"))
    //    {
    //        rightHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
    //        leftHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
    //        PlayerPrefs.SetInt("RuleHastouchplayer", 1);
    //        Destroy(gameObject);
    //    }
    //}
}
