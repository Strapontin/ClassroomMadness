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


    float timer = 0.0f;

    private GameObject countScore;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        countScore = GameObject.Find("CountScoreSystemEleve");
    }

    // Update is called once per frame
    void Update()
    {
        // On compte les secondes
        timer += Time.deltaTime;

        if (timer % 60 >= 1)
        {
            timer = 0;
            countScore.GetComponent<CountBoulette>().BouletteScored();
        }

        if (glue)
        {
            glue = false;
            transform.position = Pos;
        }

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
        if (collision.gameObject.name != "boulette_papier(Clone)" &&
            collision.gameObject.name != "Sarbacane(Clone)" &&
            collision.gameObject.name != "eleve fi Variant(Clone)")
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
