using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierEleves : MonoBehaviour
{
    public Transform origineEleve1;
    public Transform origineEleve2;
    public Transform origineEleve3;
    public Transform origineJoueur;
    private int i;
    public List<Rigidbody> rb = new List<Rigidbody>();



            // Start is called before the first frame update
            void Start()
    {
        //for (int i= 0; i <= rb.Count; i++)
        //{
        //    Rigidbody instance i;
        //    instance = Instantiate(rb[i], origineEleve1.position, origineEleve1.rotation) as Rigidbody;
        //}


        // On mélange la liste pour une disposition aléatoire des élèves

        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody temp = rb[i];
            int randomIndex = Random.Range(i, rb.Count);
            rb[i] = rb[randomIndex];
            rb[randomIndex] = temp;
        }




        Rigidbody instance;
        instance = Instantiate(rb[0], origineEleve1.position, origineEleve1.rotation) as Rigidbody;
        Rigidbody instance2;
        instance2 = Instantiate(rb[1], origineEleve2.position, origineEleve2.rotation) as Rigidbody;
        Rigidbody instance3;
        instance3 = Instantiate(rb[2], origineEleve3.position, origineEleve3.rotation) as Rigidbody;
        Rigidbody instance4;
        instance4 = Instantiate(rb[3], origineJoueur.position, origineJoueur.rotation) as Rigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
