using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarbacane : MonoBehaviour
{
    public Rigidbody Boulette;
    public Transform origine;
    public int force;
    public int forceMax;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ranger la sarbacane en la détruisant
        if (Input.GetKey(KeyCode.Y))
        {
            Destroy(gameObject, 1);
        }

        // Augmente la force du tir selon qu'on appuie longtemps sur la touche, on définit une force maximum
        if (Input.GetKey(KeyCode.Space))
        {
            force = force + 5;
        }

        if (force >= forceMax)
        {
            force = forceMax;
        }

        // Tire la boulette de papier lorsqu'on relache le bouton de tir
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Rigidbody instance;
            instance = Instantiate(Boulette, origine.position, origine.rotation) as Rigidbody;
            instance.AddForce(transform.up * force);
            force = 1;
            GameObject.Find("EleveCanvas").GetComponent<CanvasEleveManager>().SerbacaneForce(force, forceMax);
        }
    }
}
