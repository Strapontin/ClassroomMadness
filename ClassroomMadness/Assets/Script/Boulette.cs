using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulette : MonoBehaviour
{
    private Rigidbody rb;
    bool glue = false;
    Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (glue)
        {
            transform.position = Pos;
        }
        //Destroy(gameObject, 4);
    }

    void OnCollisionEnter(Collision collision)
    {

        //this.transform.parent = collision.gameObject.transform;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        //rb.constraints = RigidbodyConstraints.FreezePositionY;
        //rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Pos = transform.position;
        glue = true;
    }
}
