using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
              Debug.Log("ça touche");  
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0.1f, 0, 0);
            Debug.Log("ça touche");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, -0.1f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        transform.Translate(0, 0, 0);
        Debug.Log("ça touche");
    }
}
