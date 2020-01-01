using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierEleves : MonoBehaviour
{
    public List<GameObject> eleves;
    public List<Transform> chaise;

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
            Instantiate(eleves[i], chaise[i].position, chaise[i].rotation);
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
