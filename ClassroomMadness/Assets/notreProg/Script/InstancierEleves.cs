using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierEleves : MonoBehaviour
{
    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<Transform> chaise = new List<Transform>();
    public Transform place;

    // Start is called before the first frame update
    void Start()
    {
        spawnStudent();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnStudent()
    {
        GameObject[] eleves = GameObject.FindGameObjectsWithTag("Stud");

        foreach (GameObject eleve in eleves)
        {
            Destroy(eleve);
        }

        if (GameObject.Find("eleve fi Variant(Clone)") != null)
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

        for (int i = 0; i < rb.Count; i++)
        {
            Rigidbody instance;
            place.position = chaise[i].position + new Vector3(0f, -0.6f, 0.5f);
            place.rotation = chaise[i].rotation;
            instance = Instantiate(rb[i], place.position, place.rotation) as Rigidbody;
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<JoueurEleve>().StopStun();
    }

    public void StudentGotStunned()
    {
        StartCoroutine(DestunWait());
    }


    IEnumerator DestunWait()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<JoueurEleve>().StartStun();

        GameObject sarbacane = GameObject.Find("Sarbacane(Clone)");

        if (sarbacane != null)
        {
            Destroy(sarbacane);
        }
        
        DestroyAllBoullettes();
        yield return new WaitForSeconds(3f);
        spawnStudent();
    }


    void DestroyAllBoullettes()
    {
        var boulettes = GameObject.FindGameObjectsWithTag("boulette");

        foreach (GameObject boulette in boulettes)
        {
            Destroy(boulette);
        }
    }
}
