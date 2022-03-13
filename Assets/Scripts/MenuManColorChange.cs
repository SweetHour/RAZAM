using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManColorChange : MonoBehaviour
{
    private Renderer rendererGuy;
    public float colorChnageTime;
    // Start is called before the first frame update
    void Start()
    {
        rendererGuy = gameObject.GetComponent<Renderer>();
        InvokeRepeating("ColorChange", colorChnageTime, colorChnageTime);
    }

    private void ColorChange()
    {
        rendererGuy.material.color= new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.8f, 1.0f));
    }
}
