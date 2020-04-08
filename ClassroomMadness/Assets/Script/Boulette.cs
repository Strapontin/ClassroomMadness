using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulette : MonoBehaviour
{
    public int pvBoulette;
    private Rigidbody rb;
    bool glue = false;
    Vector3 Pos;
    private AudioSource audioSource;
    public AudioClip cleanSounds;
    public AudioClip paperGlueSounds;
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
        //Destroy(gameObject, 4);

        if (pvBoulette <= 0)
        {
            Destroy(rb.gameObject);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brosse"))
        {

            pvBoulette -= 1;
            if (audioSource.isPlaying != true)
            {
                audioSource.PlayOneShot(cleanSounds, 1);
            }

        }
    }


    void OnCollisionEnter(Collision collision)
    {

        //this.transform.parent = collision.gameObject.transform;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Pos = transform.position;
        audioSource.PlayOneShot(paperGlueSounds, 1);
        glue = true;




    }
}
