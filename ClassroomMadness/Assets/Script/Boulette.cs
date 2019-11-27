using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boulette : MonoBehaviour
{
    private GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindWithTag("ScorePC");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prof"))
        {
            int ScoreUI = int.Parse(UI.gameObject.GetComponent<Text>().text) + 1;
            UI.gameObject.GetComponent<Text>().text = ScoreUI + "";
            Destroy(gameObject);
        }
    }
}
