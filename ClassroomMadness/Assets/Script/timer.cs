using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text TimerTxt;
    private float startTime;
    private int limit = 5;

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
        //Si le prof et l'eleve sont tout les 2 prets
        if (GameObject.Find("menu_pc").GetComponent<Start_Menu>().EleveisReady == true && GameObject.Find("menu_vr").GetComponent<Start_Menu>().ProfisReady == true)
        {
            //Si un des deux n'est plus pret (A terminer)
            if (GameObject.Find("menu_pc").GetComponent<Start_Menu>().EleveisReady != true || GameObject.Find("menu_vr").GetComponent<Start_Menu>().ProfisReady != true)
            {
                startTime = 5;
                GameObject.Find("menu_pc").GetComponent<Start_Menu>().TextTimer.SetActive(false);
            }
            
            //Afficher le compteur
            GameObject.Find("menu_pc").GetComponent<Start_Menu>().TextTimer.SetActive(true);

            startTime -= 1 * Time.deltaTime;

            TimerTxt.text = startTime.ToString("f0");

            if (startTime <= 0)
            {
                LancementScene(1);
            }

                
            
        }
    }
}
