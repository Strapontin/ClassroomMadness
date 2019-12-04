﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierRegle : MonoBehaviour
{
    public Rigidbody regle;
    public Transform bureau;
    public bool timer;

    // Start is called before the first frame update
    void Start()
    {


        // On mélange la liste pour une disposition aléatoire des élèves

        // Update is called once per frame
      
    }
    void Update()
    {
     
        if (GameObject.Find("Regle(Clone)") == null)
        {
            timer = true;
            StartCoroutine(LaunchGenerateRule());
        }
    }
    IEnumerator LaunchGenerateRule()
    {
        yield return new WaitForSeconds(1.5f);
        if(timer)
        {
            Rigidbody instance;
            instance = Instantiate(regle, new Vector3(bureau.position.x, bureau.position.y + 0.5f, bureau.position.z), Quaternion.identity) as Rigidbody;
            timer = false;
        }
        
    }


}
