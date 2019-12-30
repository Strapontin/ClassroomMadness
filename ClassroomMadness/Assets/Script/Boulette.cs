using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boulette : MonoBehaviour
{
    public int pvBoulette;
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

        if (pvBoulette <= 0)
        {
            Destroy(rb.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brosse"))
        {
            pvBoulette -= 1;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //this.transform.parent = collision.gameObject.transform;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Pos = transform.position;
        glue = true;
    }
}
