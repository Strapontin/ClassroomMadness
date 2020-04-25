using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBoulette : MonoBehaviour
{

    public float nbBoulette;
    public float Score;

    // Start is called before the first frame update
    void Start()
    {
        nbBoulette = 0;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Ajout de 0.1 point si la boulette existe
        Score += 0.1f * nbBoulette * Time.deltaTime;
        if (Score % 1 == 0)
        {
            Debug.Log(Score);
        }
    }
}
