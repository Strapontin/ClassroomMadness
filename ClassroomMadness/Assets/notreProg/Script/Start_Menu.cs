using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Start_Menu : MonoBehaviour
{
    //Déclaration des éléments du menu
    public GameObject Pannel_Title;
    public GameObject Button_Play;
    public GameObject Button_Exit;
    public GameObject Button_Return_Second_Menu;
    public GameObject Panel_check_eleve_ready;
    public GameObject Panel_Section_Pret_Eleve;
    public GameObject Button_Ready;
    public GameObject Panel_check_prof_ready;
    public GameObject Panel_Section_Pret_Prof;
    public GameObject TextTimer;
    public bool EleveisReady = false;
    public bool ProfisReady = false;

    //Fonction Start
    private void Start()
    {

        //Activation des éléments par défaut
        Pannel_Title.SetActive(true);
        Button_Play.SetActive(true);
        Button_Exit.SetActive(true);

        //Désactivation des éléments par défaut
        Button_Return_Second_Menu.SetActive(false);
        Panel_check_eleve_ready.SetActive(false);
        Panel_Section_Pret_Eleve.SetActive(false);
        Button_Ready.SetActive(false);
        Panel_check_prof_ready.SetActive(false);
        Panel_Section_Pret_Prof.SetActive(false);
        TextTimer.SetActive(false);
    }

    //Fonction Play - Entrer dans le second Menu
    public void PlayGamePC()
    {
        //Désactivation des éléments Titre, boutton Play et boutton Exit
        Pannel_Title.SetActive(false);
        Button_Play.SetActive(false);
        Button_Exit.SetActive(false);

        //Activation des éléments Retour
        Button_Return_Second_Menu.SetActive(true);
        Panel_check_eleve_ready.SetActive(true);
        Button_Ready.SetActive(true);
        Panel_check_prof_ready.SetActive(true);

        //Affichage de l'état du prof VR
        if (GameObject.Find("menu_vr").GetComponent<Start_Menu>().ProfisReady == false)
        {
            Panel_Section_Pret_Prof.SetActive(false);
        }
        else
        {
            Panel_Section_Pret_Prof.SetActive(true);
        }
    }

    //Fonction Play - Entrer dans le second Menu
    public void PlayGameVR()
    {
        //Désactivation des éléments Titre, boutton Play et boutton Exit
        Pannel_Title.SetActive(false);
        Button_Play.SetActive(false);
        Button_Exit.SetActive(false);

        //Activation des éléments Retour
        Button_Return_Second_Menu.SetActive(true);
        Panel_check_eleve_ready.SetActive(true);
        Button_Ready.SetActive(true);
        Panel_check_prof_ready.SetActive(true);

        //Affichage de l'état de l'élève PC
        if (GameObject.Find("menu_pc").GetComponent<Start_Menu>().EleveisReady == false)
        {
            Panel_Section_Pret_Eleve.SetActive(false);
        }
        else
        {
            Panel_Section_Pret_Eleve.SetActive(true);
        }
    }

    //Fonction quitter le jeu depuis le Menu Start
    public void ExitGame()
    {
        Application.Quit();
    }

    //Fonction retour au Menu Start
    public void Return()
    {
        //Activation des éléments Titre, boutton Play et boutton Exit
        Pannel_Title.SetActive(true);
        Button_Play.SetActive(true);
        Button_Exit.SetActive(true);

        //Désactivation des éléments Retour
        Button_Return_Second_Menu.SetActive(false);
        Panel_check_eleve_ready.SetActive(false);
        Button_Ready.SetActive(false);
        Panel_check_prof_ready.SetActive(false);
    }
    
    //Fonction Eleve Ready
    public void EleveReady()
    {
       if(EleveisReady == false)
       {
            EleveisReady = true;
            Panel_Section_Pret_Eleve.SetActive(true);
        }
       else
       {
            EleveisReady = false;
            Panel_Section_Pret_Eleve.SetActive(false);
       }
    }

    //Fonction Prof Ready
    public void ProfReady()
    {
        if (ProfisReady == false)
        {
            ProfisReady = true;
            Panel_Section_Pret_Prof.SetActive(true);
        }
        else
        {
            ProfisReady = false;
            Panel_Section_Pret_Prof.SetActive(false);
        }
    }



}
