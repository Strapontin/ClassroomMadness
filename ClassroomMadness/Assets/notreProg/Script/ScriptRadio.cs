using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRadio : MonoBehaviour
{
    public bool MusicSuivante;
    public List<AudioSource> music = new List<AudioSource>();
    int i = 0;
    int lenghtlist;
    // Start is called before the first frame update
    void Start()
    {
        lenghtlist = music.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainVR"))
        {
            Debug.Log("tttt");
            
            if (MusicSuivante == true)
            {
                music[i].Stop();
                if (i + 1 > lenghtlist - 1)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                music[i].Play();

            }
            else
            {
                music[i].Stop();
                if (i - 1 < 0)
                {
                    i = lenghtlist - 1;
                }
                else
                {
                    i--;
                }
                music[i].Play();
           }
        }
    }
}
