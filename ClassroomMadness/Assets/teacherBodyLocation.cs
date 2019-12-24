using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teacherBodyLocation : MonoBehaviour
{
    public GameObject cam;
    public GameObject bodyProf;
    public float haut;
    public float z;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, cam.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);


        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - haut, cam.transform.position.z) + cam.transform.forward * distance; ;
    }
}
