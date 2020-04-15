using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Horloge : MonoBehaviour
{

    private float i = 180.0f;
    // vitesse de l'aiguille pour i+ = 0.1f => 60 secondes donc pour 2 min on prends i+= 0.05f
    private float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i+=speed;
        GameObject.Find("Aiguille").transform.rotation = Quaternion.Euler(0, 0, -i);


        // Lorsque la l'aiguille fait un tour complet on signale la fin du jeu
        if (GameObject.Find("Aiguille").transform.rotation == Quaternion.Euler(0, 0, 180f))
        {
            // refresh la scene quand le temps est écoulé (test)
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Debug.Log("Fin du jeu");
        }
    }


}
