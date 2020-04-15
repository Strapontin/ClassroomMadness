using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class JoueurEleve : MonoBehaviour

{
    public float horizontalSpeed = 4.0F;
    public float verticalSpeed = 4.0F;
    public bool enter = true;

    public Transform Camera;
    public Transform emp_Camera_Debout;
    public Transform emp_Camera_Assis;

    public GameObject Joueur;
    public Rigidbody Sarbacane;
    public Transform origine;
    public float gravity = 10f;
    public float speed = 10f;
    public CharacterController Cc;
    Vector3 moveDir;
    Vector3 moveDirHori;
    private float distanceMove;
    public Material[] material;
    Renderer rend;
    public bool canHeMove;
    public Rigidbody rb;

    GameObject ChaiseNear;
    public Animator animator;

    private AudioSource audioSource;
    public AudioClip[] walkSounds;
    public AudioClip chairSounds;


    void Start()
    {
        Cc = GetComponent<CharacterController>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
       // rend.sharedMaterial = material[0];
        animator = GetComponent<Animator>();
        canHeMove = false;
        Debug.Log(distanceMove);

        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
    }

    // Update is called once per frame
    void Update()
    {
        distanceMove = Vector3.Distance(moveDir, new Vector3(0, 0, 0));

        // Position de la caméra lorsqu'il est assis ou debout, la tête lors de l'animation assis et debout ne se trouve pas au même endroit 
        if (canHeMove == true)
        {
            Camera.position = emp_Camera_Debout.position;
            Cc.enabled = true;
        }
        else if (canHeMove == false)
        {
            Camera.position = emp_Camera_Assis.position;
            Cc.enabled = false;
        }


        if (canHeMove)
        {
            // Déplacement du personnage
            if (Cc.isGrounded)
            {
                moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;

                moveDirHori = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                moveDirHori = transform.TransformDirection(moveDirHori);
                moveDirHori *= speed;
            }
            moveDir.y -= gravity * Time.deltaTime;
            moveDirHori.y -= gravity * Time.deltaTime;
            //transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 2 * 10);


            Cc.Move(moveDir * Time.deltaTime);

            Cc.Move(moveDirHori * Time.deltaTime);


        }

            if (distanceMove > 2f && Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("Walk Back", true);
            speed = 5f;
            if (audioSource.isPlaying != true)
            {
                PlayFootStepAudio();
            }

        }
           else if (distanceMove > 2f && Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("Run", true);
            speed = 10f;

            //PlayFootStepAudio();
            if (audioSource.isPlaying != true)
            {
                PlayFootStepAudio();
            }

        }

        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk Back", false);
            speed = 10f;
        }
        
        if ( Input.GetAxis("Horizontal") < 0 && canHeMove == true)
        {
            animator.SetBool("Left", true);
            speed = 5f;
            if (audioSource.isPlaying != true)
            {
                PlayFootStepAudio();
            }

        }
        else if (Input.GetAxis("Horizontal") > 0 && canHeMove == true)
        {
            animator.SetBool("Right", true);
            speed = 5f;

            //PlayFootStepAudio();
            if (audioSource.isPlaying != true)
            {
                PlayFootStepAudio();
            }

        }
        else
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            speed = 10f;
        }


        if (canHeMove == false && Input.GetKeyDown(KeyCode.M))
        {
            canHeMove = true;
            Cc.enabled = true;
            audioSource.PlayOneShot(chairSounds);
            animator.SetBool("Sit", false);


        }
        else if (canHeMove == true && Input.GetKeyDown(KeyCode.M))
        {
            canHeMove = false;

            //gameObject.transform.position = new Vector3(ChaiseNear.transform.position.x, ChaiseNear.transform.position.y + 1, ChaiseNear.transform.position.z);
            rb.isKinematic = true;
            animator.SetBool("Sit", true);
        }


        // Apparition de la sarbacane

        if (Input.GetKeyUp(KeyCode.I) && GameObject.Find("Sarbacane(Clone)") == null)
        {
            Rigidbody instance;
            instance = Instantiate(Sarbacane, origine.position, origine.rotation, Joueur.transform.parent) as Rigidbody;
        }

        //-----------------------------------------------------------------//



    }



    private void PlayFootStepAudio()
    {
            int n = Random.Range(1, walkSounds.Length);
            audioSource.clip = walkSounds[n];
            audioSource.PlayOneShot(audioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            walkSounds[n] = walkSounds[0];
            walkSounds[0] = audioSource.clip;
            Debug.Log("marche");
    }


    void OnCollisionEnter(Collision collision)
    {


        transform.Translate(0, 0, 0);
        if (collision.gameObject.CompareTag("Chaise"))
        {
            Debug.Log("chaise detecter");
            Debug.Log(canHeMove);
        }

        if (collision.gameObject.CompareTag("Chaise"))
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


