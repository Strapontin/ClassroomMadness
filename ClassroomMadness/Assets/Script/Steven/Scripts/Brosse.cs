using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brosse : MonoBehaviour
{
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Fonction qui détruit au bout de 5 secondes après avoir été touché
    //void  OnCollisionEnter(Collision collision)
    //{


    //    if (collision.gameObject.CompareTag("boulette"))
    //    {


    //        //StartCoroutine(waitToDestroy());
    //        //Destroy(collision.gameObject);

    //    }

    //IEnumerator waitToDestroy()
    //{
    //    yield return new WaitForSeconds(5.0f);
    //    if (collision.gameObject.CompareTag("boulette"))
    //    {
    //        Destroy(collision.gameObject);
    //    }

        //}
        //}



    }
