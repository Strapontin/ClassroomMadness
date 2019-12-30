﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierEleves : MonoBehaviour
{
    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<Transform> chaise = new List<Transform>();

    private DateTime d;
       
    // Start is called before the first frame update
    void Start()
    {
        // On mélange la liste pour une disposition aléatoire des élèves
        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody temp = rb[i];
            int randomIndex = UnityEngine.Random.Range(i, rb.Count);
            rb[i] = rb[randomIndex];
            rb[randomIndex] = temp;
        }

        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody instance;
            instance = Instantiate(rb[i], chaise[i].position, chaise[i].rotation) as Rigidbody;
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
        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody temp = rb[i];
            int randomIndex = UnityEngine.Random.Range(i, rb.Count);
            rb[i] = rb[randomIndex];
            rb[randomIndex] = temp;
        }

        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody instance;
            instance = Instantiate(rb[i], chaise[i].position, chaise[i].rotation) as Rigidbody;
        }
    }
}
