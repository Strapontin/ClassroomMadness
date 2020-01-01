using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RegleScript : MonoBehaviour
{
    private GameObject rightHand;
    private GameObject leftHand;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rightHand = GameObject.Find("LeftHand");
        leftHand = GameObject.Find("RightHand");

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Eleve") ||
            collision.gameObject.CompareTag("EleveJoueur"))
        {
            rightHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
            leftHand.gameObject.GetComponent<Hand>().DetachObject(gameObject, false);
            Destroy(gameObject);
        }
    }
}
