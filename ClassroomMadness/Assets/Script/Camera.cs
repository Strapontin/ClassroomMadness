using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

   

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private float xmin = -30f;
    private float xmax = 50f;
    private float ymin = -90f;
    private float ymax = 90f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Variable pour le déplacement de l'axe Y
        yaw += speedH * Input.GetAxis("Mouse X");

        // Variable pour le déplacement de l'axe X
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Délimiter la rotation de l'axe de Y
        if (yaw < ymin)
        {
            yaw = ymin;
        }
        else if (yaw > ymax){
            yaw = ymax;
        }

        // Délimiter la rotation de l'axe de X
        if (pitch < xmin)
        {
            pitch = xmin;
        }
        else if (pitch > xmax){
            pitch = xmax;
        }
    }
}
