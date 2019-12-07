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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rightHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
            leftHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
            Destroy(gameObject);
        }
    }
}
