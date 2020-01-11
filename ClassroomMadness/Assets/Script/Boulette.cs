using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boulette : MonoBehaviour
{
    private GameObject UI;
    private Rigidbody rb;
    Vector3 Pos;
    bool glue = false;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindWithTag("ScorePC");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(glue)
        {
            transform.position = Pos;
        }
        //Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionX;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;

       
        rb.constraints = RigidbodyConstraints.FreezeRotation;
       
        Pos = transform.position;
        glue = true;
        /*
        if (collision.gameObject.CompareTag("Prof"))
        {
            int ScoreUI = int.Parse(UI.gameObject.GetComponent<Text>().text) + 1;
            UI.gameObject.GetComponent<Text>().text = ScoreUI + "";
            Destroy(gameObject);
        }*/
    }
}
