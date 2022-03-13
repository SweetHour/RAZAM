using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardFlying : MonoBehaviour
{
    private Vector3 startPos;
    private float movement, time;
    private bool switcher;

    // Start is called before the first frame update
    void Start()
    {
        movement = Random.Range(0f, 3f);
        time = Random.Range(0.5f, 1.5f);
        startPos = transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-movement / 2, movement / 2), transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (switcher == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime / time);
        }
        if (switcher == false)
        {
            transform.Translate(Vector3.down * Time.deltaTime / time);
        }

        if (Mathf.Abs(transform.position.y - startPos.y) > movement) { switcher = !switcher; }

    }
}
