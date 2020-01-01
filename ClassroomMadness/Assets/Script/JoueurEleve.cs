using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurEleve : MonoBehaviour
{
    public float horizontalSpeed = 4.0F;
    public float verticalSpeed = 4.0F;
    public Rigidbody rb;

    //public GameObject Joueur;
    public Rigidbody Sarbacane;
    public Transform origine;
    public float gravity = 10f;
    public float speed = 10f;
    private CharacterController Cc;
    Vector3 moveDir;
    public Material[] material;
    Renderer rend;
    private bool canHeMove = true;

    GameObject ChaiseNear;

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
        if(canHeMove)
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
        }

        if (canHeMove == false && Input.GetKeyDown(KeyCode.M))
        {
            canHeMove = true;     
        }
        else if(canHeMove == true && Input.GetKeyDown(KeyCode.M))
        {
            canHeMove = false;

            Debug.Log(ChaiseNear.transform.position);
            gameObject.transform.position = new Vector3(ChaiseNear.transform.position.x, ChaiseNear.transform.position.y + 1, ChaiseNear.transform.position.z);
        }

        // Apparition de la sarbacane
        if (Input.GetKey(KeyCode.I) && GameObject.Find("Sarbacane(Clone)") == null)
        {
            Instantiate(Sarbacane, origine.position, origine.rotation, gameObject.transform.parent);
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

        if(collision.gameObject.CompareTag("Chaise"))
        {
            Debug.Log("chaise detecter");
            Debug.Log(canHeMove);
        }

        if(collision.gameObject.CompareTag("Chaise"))
        {
            ChaiseNear = collision.gameObject;
            Debug.Log(ChaiseNear.transform.position.x);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chaise"))
        {
            ChaiseNear = null;
        }
    }
}
