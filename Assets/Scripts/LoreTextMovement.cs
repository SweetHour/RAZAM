using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreTextMovement : MonoBehaviour
{
   
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
        }
    }


}
