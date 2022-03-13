using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFalling : MonoBehaviour
{
    [SerializeField] private float _gravity = 10.0f;
    [SerializeField] private float _velocity = 0.0f;
    [SerializeField] private float _time = 2.0f;

    [SerializeField] private bool isWingPlayed;

    [SerializeField] private AudioClip wingSound;
    [SerializeField] private AudioSource wingAudio;
    private CharacterController controller;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_velocity > -_gravity) _velocity -= _gravity * Time.deltaTime * 2 / _time;
            if (_velocity > 0) _velocity -= _gravity * Time.deltaTime * 3 / _time;
        }
        else
        {
            if (_velocity < _gravity*1.5)
            {
                _velocity += _gravity * Time.deltaTime * 2.3f / _time;
                
            }
            StopAllCoroutines();
        }
        controller.Move(_velocity * Vector3.down * Time.deltaTime);

        if (_velocity < 0&&!isWingPlayed) { wingAudio.clip = wingSound; wingAudio.Play(); isWingPlayed = true; StartCoroutine(WingAgain()); }
        if (_velocity > 0 ) { isWingPlayed = false;  }


        
    }

    IEnumerator WingAgain()
    {
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(WingAgain());
        wingAudio.clip = wingSound;
        wingAudio.Play();
    }

}

   


