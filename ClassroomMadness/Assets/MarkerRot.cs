using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MarkerRot : MonoBehaviour
{
    private Rigidbody rb;
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
     //   if (rightHand.gameObject.GetComponent<Hand>().AttachedObjects.) ;
    }
}
