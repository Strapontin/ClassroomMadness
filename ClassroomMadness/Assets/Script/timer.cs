using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text TimerTxt;
    private float startTime;

    public void LancementScene(int nbScene)
    {
        SceneManager.LoadScene(nbScene, LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        bool theTwoAreReady = GameObject.Find("menu_pc").GetComponent<Start_Menu>().EleveisReady;
        switch (theTwoAreReady)
        {
            case true:
                //Le timer s'affiche
                GameObject.Find("menu_pc").GetComponent<Start_Menu>().TextTimer.SetActive(true);
                //Le bouton Pret disparait
                GameObject.Find("menu_pc").GetComponent<Start_Menu>().Button_Ready.SetActive(false);

                //Le timer est lancé
                startTime -= 1 * Time.deltaTime;
                //Changement de la valeur de timer en string pour ne garder que l'unité
                TimerTxt.text = startTime.ToString("f0");

                //Si le timer arrive à 0
                if (startTime <= 0)
                {
                    //La scene principal commence
                    LancementScene(1);
                }
                break;
            case false:
                //Le timer ne s'affiche pas
                GameObject.Find("menu_pc").GetComponent<Start_Menu>().TextTimer.SetActive(false);
                break;
        }
    }
}
