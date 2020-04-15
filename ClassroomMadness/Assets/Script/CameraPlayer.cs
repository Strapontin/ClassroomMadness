using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation = 0f;
    private float yRotation = 0f;


    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float ver = 0.0f;
    private float hor = 0.0f;

    private float xmin = -30f;
    private float xmax = 50f;
    private float ymin = -90f;
    private float ymax = 90f;

    private bool sit = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        // Bug quand on veut récuperer la valeur de la variable du joueur éléve quand il est assis ou pas:  GetComponent<JoueurEleve>().canHeMove = sit;

       if (sit == true && Input.GetKeyDown(KeyCode.M))
        {
            sit = false;
        }
       else if (sit == false && Input.GetKeyDown(KeyCode.M))
        {
            sit = true;
        }


        if (sit == false)
        {

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseX;

            yRotation -= mouseY;


           
            transform.localRotation = Quaternion.Euler(yRotation, mouseX, 0f);
            playerBody.Rotate(Vector3.up * mouseX);


            Debug.Log("transform local rotation" + transform.localRotation);


        }

        // Caméra lorsque le joueur est assis
        else if (sit == true)
        {
            // Variable pour le déplacement de l'axe Y
            hor += speedH * Input.GetAxis("Mouse X");

            // Variable pour le déplacement de l'axe X
            ver -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(ver, hor, 0.0f);

            // Délimiter la rotation de l'axe de Y
            if (hor < ymin)
            {
                hor = ymin;
            }
            else if (hor > ymax)
            {
                hor = ymax;
            }

            // Délimiter la rotation de l'axe de X
            if (ver < xmin)
            {
                ver = xmin;
            }
            else if (ver > xmax)
            {
                ver = xmax;
            }
        }
    }
}