using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcstud : MonoBehaviour
{
    Animator animator;
    public GameObject starSystem;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Regle") && GameObject.Find("startSystem(Clone)") == null)
        {
            animator.SetBool("stun", true);
            starSystem.SetActive(true);
        }
    }
}
