using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarbacane : MonoBehaviour
{
    public Rigidbody Boulette;
    public Transform origine;
    public int force = 1;
    public int forceMax = 100;
    public int forcePlus = 1;

    private AudioSource audioSource;
    public AudioClip shootSounds;
    public AudioClip paperSounds;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD

=======
        audioSource = GetComponent<AudioSource>();
>>>>>>> Steven
    }

    // Update is called once per frame
    void Update()
    {
        // Ranger la sarbacane en la détruisant

        if (Input.GetKey(KeyCode.Y))
        {
            force += forcePlus;
        }


        // Préparer la boulette de papier pendant une durée 
        if (Input.GetKeyUp(KeyCode.B) && bouletteUp == false)
        {
            StartCoroutine(preparerBoulette());
        }

        IEnumerator preparerBoulette()
        {
            audioSource.PlayOneShot(paperSounds,1);
            yield return new WaitForSeconds(3.0f);
            Debug.Log("Boulette prête");
            bouletteUp = true;
            yield return new WaitForSeconds(1.0f);

>>>>>>> Steven
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            force = force / 10;

            var instance = Instantiate(Boulette, origine.position, origine.rotation) as Rigidbody;
            instance.AddForce((-gameObject.transform.up) * force, ForceMode.Impulse);

            Debug.Log("Boulette force = " + force);

<<<<<<< HEAD
=======
        if (Input.GetKeyUp(KeyCode.Space) && bouletteUp == true)
        {
            audioSource.PlayOneShot(shootSounds,1);
            Rigidbody instance;
            instance = Instantiate(Boulette, origine.position, origine.rotation) as Rigidbody;
            instance.AddForce(transform.up * force);
>>>>>>> Steven
            force = 1;
        }
    }
}
