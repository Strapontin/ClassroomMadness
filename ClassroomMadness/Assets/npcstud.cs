using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcstud : MonoBehaviour
{
    Animator animator;
    public GameObject starSystem;
    private float Stuntime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Stuntime <= 0)
       {
            animator.SetBool("stun", false);
            starSystem.SetActive(false);
       }
       else
       {
           Stuntime -= 1 * Time.deltaTime;
       }
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Regle") && GameObject.Find("startSystem(Clone)") == null)
        {
            animator.SetBool("stun", true);
            starSystem.SetActive(true);
            Stuntime = 3;
        }
    }
}
