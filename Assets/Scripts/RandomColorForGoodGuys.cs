using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorForGoodGuys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(0.6f + Random.Range(0.0f, 0.3f), 0.6f + Random.Range(0.0f, 0.3f), 0.6f + Random.Range(0.0f, 0.3f), 0.7f + Random.Range(0.0f, 0.3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
