using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float xRotation, yRotation, zRotation,rotationSpeed;
    public bool isRandom;
    private Vector3 rotationAngle;
    // Start is called before the first frame update
    void Start()
    {
        if (isRandom)
        {
            xRotation = Random.Range(-1f, 1f);
            yRotation = Random.Range(-1f, 1f);
            zRotation = Random.Range(-1f, 1f);
            rotationSpeed = Random.Range(5f, 150f);
        } 
        rotationAngle = new Vector3(xRotation, yRotation, zRotation);
        
    }
    // Update is called once per frame
    void Update()
    {
       
            transform.Rotate(rotationAngle*Time.deltaTime*rotationSpeed,Space.World);
        
        
    }
}
