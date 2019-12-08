using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierEleves : MonoBehaviour
{
    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<Transform> chaise = new List<Transform>();



    // Start is called before the first frame update
    void Start()
    {


        // On mélange la liste pour une disposition aléatoire des élèves

        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody temp = rb[i];
            int randomIndex = Random.Range(i, rb.Count);
            rb[i] = rb[randomIndex];
            rb[randomIndex] = temp;
        }

        // 
        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody instance;
            instance = Instantiate(rb[i], chaise[i].position, chaise[i].rotation) as Rigidbody;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
