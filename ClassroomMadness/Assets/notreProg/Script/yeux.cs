using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeux : MonoBehaviour
{
    public GameObject cam;
    public float haut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y -haut , cam.transform.position.z);
        transform.rotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, cam.transform.rotation.eulerAngles.y, cam.transform.rotation.eulerAngles.z);
    }
}
