using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulette : MonoBehaviour
{
    public int pvBoulette = 1;
    private Rigidbody rb;
    bool glue = false;
    Vector3 Pos;
    private AudioSource audioSource;
    public AudioClip cleanSounds;
    public AudioClip paperGlueSounds;


    private GameObject countScore1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        countScore1 = GameObject.Find("CountScoreSystemEleve");
    }

    // Update is called once per frame
    void Update()
    {
        if (glue)
        {
            glue = false;
            transform.position = Pos;
            countScore1.GetComponent<CountBoulette>().nbBoulette += 1;
        }
        //Destroy(gameObject, 4);

        if (pvBoulette <= 0)
        {
            countScore1.GetComponent<CountBoulette>().nbBoulette -= 1;
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

    private void OnTriggerEnter(Collider collision)
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
        if(collision.gameObject.name != "boulette_papier(Clone)")
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Pos = transform.position;
            audioSource.PlayOneShot(paperGlueSounds, 1);
            glue = true;
        }

    }
}
