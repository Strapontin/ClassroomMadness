using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierEleves : MonoBehaviour
{
<<<<<<< HEAD
    public List<GameObject> eleves;
    public List<Transform> chaise;
=======
    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<Transform> chaise = new List<Transform>();
    public List<Transform> place = new List<Transform>();

>>>>>>> Steven

    private DateTime d;

    // Start is called before the first frame update
    void Start()
    {
        // On mélange la liste pour une disposition aléatoire des élèves
        for (int i = 0; i < eleves.Count; i++)
        {
            GameObject temp = eleves[i];
            int randomIndex = UnityEngine.Random.Range(i, eleves.Count);
            eleves[i] = eleves[randomIndex];
            eleves[randomIndex] = temp;
        }

        for (int i = 0; i < eleves.Count; i++)
        {
<<<<<<< HEAD
            Instantiate(eleves[i], chaise[i].position, chaise[i].rotation);
=======
            Rigidbody instance;
            place[i].position = chaise[i].position + new Vector3(0.1f, -0.80f, 0.1f);
            place[i].rotation = chaise[i].rotation;
            instance = Instantiate(rb[i], place[i].position, place[i].rotation ) as Rigidbody;
>>>>>>> Steven
        }

        d = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        //if (DateTime.Now.Subtract(d).TotalSeconds >= 5)
        //{
        //    //CreateEleves();

        //    d = DateTime.Now;
        //}
    }


    void CreateEleves()
    {
        // On mélange la liste pour une disposition aléatoire des élèves
        for (int i = 0; i < eleves.Count; i++)
        {
            GameObject temp = eleves[i];
            int randomIndex = UnityEngine.Random.Range(i, eleves.Count);
            eleves[i] = eleves[randomIndex];
            eleves[randomIndex] = temp;
        }

        for (int i = 0; i < eleves.Count; i++)
        {
            Instantiate(eleves[i], chaise[i].position, chaise[i].rotation);
        }
    }
}
