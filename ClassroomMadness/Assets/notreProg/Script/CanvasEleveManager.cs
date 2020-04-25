using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasEleveManager : MonoBehaviour
{
    public GameObject ForceSarbacane1;
    public GameObject ForceSarbacane2;
    public GameObject ForceSarbacane3;
    public GameObject ForceSarbacane4;
    public GameObject ForceSarbacane5;

    public GameObject scoreValue;
    int scoreValuefloat;
    public GameObject scorePrintable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreValuefloat = (int) scoreValue.GetComponent<CountBoulette>().Score ;
        scorePrintable.GetComponent<Text>().text = scoreValuefloat + "";
    }

    //public void SerbacaneForce(int force, int forceMax)
    //{
    //    ForceSarbacane1.SetActive(false);
    //    ForceSarbacane2.SetActive(false);
    //    ForceSarbacane3.SetActive(false);
    //    ForceSarbacane4.SetActive(false);
    //    ForceSarbacane5.SetActive(false);
    //    if (force == 0)
    //    {
    //        ForceSarbacane1.SetActive(true);
    //    }
    //    else if (force > 0 && force <= forceMax / 2)
    //    {
    //        ForceSarbacane2.SetActive(true);
    //    }
    //    else if (force > forceMax / 2 && force < forceMax - forceMax/4)
    //    {
    //        ForceSarbacane3.SetActive(true);
    //    }
    //    else if (force > forceMax - forceMax / 4 && force < forceMax)
    //    {
    //        ForceSarbacane4.SetActive(true);
    //    }
    //    else if (force == forceMax)
    //    {
    //        ForceSarbacane5.SetActive(true);
    //    }
    //}
}
