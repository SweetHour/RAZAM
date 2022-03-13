using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownBounds : MonoBehaviour
{
    public Vector3 startPos;
    public float upBound, lowBound;
   
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > upBound)
        {
           controller.Move(startPos-transform.position);
        }
       
        if (transform.position.y < lowBound)
        {
            controller.Move(startPos - transform.position);
        }
       


    }
}
