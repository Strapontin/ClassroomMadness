using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurEleve : MonoBehaviour
{
    public float horizontalSpeed = 4.0F;
    public float verticalSpeed = 4.0F;
    public bool enter = true;
    public Rigidbody rb;

    public GameObject Joueur;
    public Rigidbody Sarbacane;
    public Transform origine;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Déplacement du personnage

        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(0.1f, 0, 0);

        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(0, 0, -0.1f);
        }


        // Déplacement de la caméra de façon gauche/droite
        
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);


        // Apparition de la sarbacane

        if (Input.GetKey(KeyCode.T) && GameObject.Find("Sarbacane(Clone)") == null)
        {
            Rigidbody instance;
            instance = Instantiate(Sarbacane, origine.position, origine.rotation, Joueur.transform.parent) as Rigidbody;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entered");
        transform.Translate(0, 0, 0);
    }
}
