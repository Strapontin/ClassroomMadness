using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horloge : MonoBehaviour
{

    private float i = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        i=i+0.5f;
        GameObject.Find("Aiguille").transform.rotation = Quaternion.Euler(0, 0, -i);
    }


}
