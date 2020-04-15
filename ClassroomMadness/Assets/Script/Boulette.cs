using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boulette : MonoBehaviour
{
    public int pvBoulette;
    private Rigidbody rb;
    bool glue = false;
    Vector3 Pos;
<<<<<<< HEAD
    
=======
    private AudioSource audioSource;
    public AudioClip cleanSounds;
    public AudioClip paperGlueSounds;
>>>>>>> Steven
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (glue)
        {
            transform.position = Pos;
        }

        if (pvBoulette <= 0)
        {
            Destroy(rb.gameObject);
        }
    }

<<<<<<< HEAD
    /*    private void OnCollisionStay(Collision collision)
=======
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brosse"))
>>>>>>> Steven
        {
            if (collision.gameObject.CompareTag("Brosse"))
            {
                pvBoulette -= 1;
            }
        }*/

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Brosse"))
        {
            pvBoulette -= 1;
<<<<<<< HEAD
=======
            if (audioSource.isPlaying != true)
            {
                audioSource.PlayOneShot(cleanSounds, 1);
            }

>>>>>>> Steven
        }
        Debug.Log(collision.gameObject.tag);
        Debug.Log(pvBoulette);
        Debug.Log(collision.gameObject.CompareTag("Brosse"));
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

<<<<<<< HEAD
        if (collision.gameObject.tag != "Boulette" &&
            collision.gameObject.tag != "EleveJoueur" &&
            collision.gameObject.tag != "Eleve")
        {
            //this.transform.parent = collision.gameObject.transform;
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Pos = transform.position;
            glue = true;
        }
=======
        //this.transform.parent = collision.gameObject.transform;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Pos = transform.position;
        audioSource.PlayOneShot(paperGlueSounds, 1);
        glue = true;




>>>>>>> Steven
    }
}
