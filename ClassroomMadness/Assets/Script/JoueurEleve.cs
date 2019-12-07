using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurEleve : MonoBehaviour
{
    public float horizontalSpeed = 4.0F;
    public float verticalSpeed = 4.0F;
    public bool enter = true;


    public GameObject Joueur;
    public Rigidbody Sarbacane;
    public Transform origine;
    public float gravity = 10f;
    public float speed = 10f;
    public CharacterController Cc;
    Vector3 moveDir;
    public Material[] material;
    Renderer rend;
    void Start()
    {
        Cc = GetComponent<CharacterController>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        
        // Déplacement du personnage
        if (Cc.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Vertical"), 0, 0);
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }
        moveDir.y -= gravity * Time.deltaTime;

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 2 * 10);


        Cc.Move(moveDir * Time.deltaTime);

        // Déplacement de la caméra de façon gauche/droite
        
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);


        // Apparition de la sarbacane

        if (Input.GetKey(KeyCode.I) && GameObject.Find("Sarbacane(Clone)") == null)
        {
            Rigidbody instance;
            instance = Instantiate(Sarbacane, origine.position, origine.rotation, Joueur.transform.parent) as Rigidbody;
        }
        if(GameObject.Find("Sarbacane(Clone)") != null)
        {
            rend.sharedMaterial = material[1];
        }
        
        if (Input.GetKey(KeyCode.P) && GameObject.Find("Sarbacane(Clone)") != null)
        {
            Destroy(GameObject.Find("Sarbacane(Clone)"));
            rend.sharedMaterial = material[0];
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.Translate(0, 0, 0);
        
    }
}
