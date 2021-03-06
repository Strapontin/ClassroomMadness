﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEleveManager : MonoBehaviour
{
    public GameObject ForceSarbacane1;
    public GameObject ForceSarbacane2;
    public GameObject ForceSarbacane3;
    public GameObject ForceSarbacane4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SerbacaneForce(int force, int forceMax)
    {
        if (force < forceMax / 4)
        {
            ForceSarbacane1.SetActive(true);
            ForceSarbacane2.SetActive(false);
            ForceSarbacane3.SetActive(false);
            ForceSarbacane4.SetActive(false);
        }
        else if (force >= forceMax / 4 && force <= forceMax / 2)
        {
            ForceSarbacane1.SetActive(false);
            ForceSarbacane2.SetActive(true);
            ForceSarbacane3.SetActive(false);
            ForceSarbacane4.SetActive(false);
        }
        else if (force == forceMax / 2)
        {
            ForceSarbacane1.SetActive(false);
            ForceSarbacane2.SetActive(false);
            ForceSarbacane3.SetActive(true);
            ForceSarbacane4.SetActive(false);
        }
        else if (force > forceMax - (forceMax / 4))
        {
            ForceSarbacane1.SetActive(false);
            ForceSarbacane2.SetActive(false);
            ForceSarbacane3.SetActive(false);
            ForceSarbacane4.SetActive(true);
        }
        else if(force == 1)
        {
            ForceSarbacane1.SetActive(false);
            ForceSarbacane2.SetActive(false);
            ForceSarbacane3.SetActive(false);
            ForceSarbacane4.SetActive(false);
        }
    }
}
