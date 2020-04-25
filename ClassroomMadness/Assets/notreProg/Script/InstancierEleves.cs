using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierEleves : MonoBehaviour
{
    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<Transform> chaise = new List<Transform>();
    public List<Transform> place = new List<Transform>();



    // Start is called before the first frame update
    void Start()
    {
        spawnStudent();
    }

    // Update is called once per frame
    void Update() { 
  //  {
  //    if (PlayerPrefs.GetInt("RuleHastouchplayer") == 1)
  //  {

    ///          PlayerPrefs.SetInt("RuleHastouchplayer", 0);

    //        spawnStudent();
    //      }
    //    }
}
    public void spawnStudent()
    {
          while(GameObject.Find("EleveNPC(Clone)") != null)
          {
               Destroy(GameObject.Find("EleveNPC(Clone)"));
          }
         while(GameObject.Find("eleve fi Variant(Clone)") != null)
        {
            Destroy(GameObject.Find("eleve fi Variant(Clone)"));
        }
        // On mélange la liste pour une disposition aléatoire des élèves

        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody temp = rb[i];
            int randomIndex = Random.Range(i, rb.Count);
            rb[i] = rb[randomIndex];
            rb[randomIndex] = temp;
        }

        // 
        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody instance;
            place[i].position = chaise[i].position + new Vector3(0f, -0.6f, 0.5f);
            place[i].rotation = chaise[i].rotation;
            instance = Instantiate(rb[i], place[i].position, place[i].rotation) as Rigidbody;
        }
    }
}
