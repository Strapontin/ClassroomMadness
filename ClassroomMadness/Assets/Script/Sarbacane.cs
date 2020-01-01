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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Augmente la force du tir selon qu'on appuie longtemps sur la touche, on définit une force maximum
        if (Input.GetKey(KeyCode.Space))
        {
            force += forcePlus;
        }

        if (force >= forceMax)
        {
            force = forceMax;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            force = force / 10;

            var instance = Instantiate(Boulette, origine.position, origine.rotation) as Rigidbody;
            instance.AddForce((-gameObject.transform.up) * force, ForceMode.Impulse);

            Debug.Log("Boulette force = " + force);

            force = 1;
        }
    }
}
