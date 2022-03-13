using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{


    public GameObject[] men;
    public AudioClip[] phrases;
    public int current;
    // Start is called before the first frame update
    void Start()
    {
        current = Random.Range(0, men.Length);
        men[current].GetComponent<AudioSource>().clip = phrases[Random.Range(0, phrases.Length)];
        men[current].GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!men[current].GetComponent<AudioSource>().isPlaying)
        {
            current = Random.Range(0, men.Length);
            men[current].GetComponent<AudioSource>().clip = phrases[Random.Range(0, phrases.Length)];
            men[current].GetComponent<AudioSource>().Play();
        }
    }
}
