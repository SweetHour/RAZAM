using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLightRotation : MonoBehaviour
{
    public float fullRotationCircle;
    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero+Vector3.right*90f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * 360f * Vector3.right/fullRotationCircle);
    }
}
