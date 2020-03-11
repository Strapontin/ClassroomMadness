using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class raycast_Hand_VR : MonoBehaviour
{
    private GameObject hand;
    private LineRenderer linerender;


    // Start is called before the first frame update
    void Start()
    {
        linerender = gameObject.GetComponent<LineRenderer>();
        hand = gameObject;

        //hand = GetComponent<Hand>
    }

    // Update is called once per frame
    void Update()
    {
        var grab = SteamVR_Actions._default.GrabGrip;
        
        //TODO
        // Devrait renvoyer TRUE ou FALSE si on appuie sur la gachette. 
        // Si ça ne fonctionne pas, essayer de changer "GrabGrip" par d'autres choses qui semblerait cohérentes. 
        // Si ça ne fonctionne toujours pas, commenter cette partie et informer Anthony au prochain cours
        Debug.Log("GRAB = " + grab.stateDown);


        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;

        //Vector3 position = transform.TransformDirection(transform.forward * 10);

        Ray ray = new Ray(transform.position + transform.forward, transform.forward);


        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ray, out hit))
        {
           // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.yellow);
           // Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward)* 5, Color.green);
            linerender.SetPosition(1, gameObject.transform.position);
            linerender.SetPosition(0, transform.TransformDirection(Vector3.forward) * 2 + transform.position);
            linerender.enabled = true;


            if (hit.collider != null && hit.collider.gameObject.CompareTag("objetAttrapable"))
            {
                Debug.Log("objet attrapable par la force");
                Debug.Log(hit.collider.gameObject.name);
                //hand.GetComponent<Hand>().AttachObject(hit.collider.gameObject, GrabTypes.Grip);
                    

                Debug.Log("INPUT = " + Input.GetMouseButtonDown(0));
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
