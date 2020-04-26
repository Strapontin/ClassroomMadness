using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarbacane : MonoBehaviour
{

    CanvasEleveManager canvasEleveManager;

    public Rigidbody Boulette;
    public Transform origine;
    public int force;
    public int forceMax;
    public int forcePlus;
    private bool bouletteUp = false;
    private bool coroutineStarted = false;

    private AudioSource audioSource;
    public AudioClip shootSounds;
    public AudioClip paperSounds;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        canvasEleveManager = GameObject.Find("EleveCanvas").GetComponent<CanvasEleveManager>();

        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("eleve fi Variant(Clone)");

    }

    // Update is called once per frame
    void Update()
    {
        // Ranger la sarbacane en la détruisant
        if (Input.GetKeyUp(KeyCode.E))
        {
            Destroy(gameObject);
        }


        // Préparer la boulette de papier pendant une durée 
        if (bouletteUp == false && !coroutineStarted)
        {
            StartCoroutine(preparerBoulette());
        }

        IEnumerator preparerBoulette()
        {
            coroutineStarted = true;
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Boulette prête");
            bouletteUp = true;
            coroutineStarted = false;
        }

        // Augmente la force du tir selon qu'on appuie longtemps sur la touche, on définit une force maximum
        if (Input.GetMouseButton(0) && bouletteUp == true && player.GetComponent< Animator>().GetBool("stun") == false)
        {
            force = force + forcePlus;
        }

        if (force >= forceMax)
        {
            force = forceMax;
        }

        // Tire la boulette de papier lorsqu'on relache le bouton de tir
        if (Input.GetMouseButtonUp(0) && bouletteUp == true)
        {
            audioSource.PlayOneShot(shootSounds, 1);
            Rigidbody instance;
            instance = Instantiate(Boulette, origine.position, origine.rotation) as Rigidbody;
            instance.AddForce(transform.up * force);
            force = 0;
            bouletteUp = false;
        }
    }
}