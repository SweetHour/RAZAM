using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 6.5f;
    [SerializeField] [Range(0.0f, 0.5f)] private float _moveSmoothTime = 0.3f;

    private CharacterController controller;


    private Vector2 _currentDir = Vector2.zero;
    private Vector2 _currentDirVelocity = Vector2.zero;
    
    
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
        _currentDir = Vector2.SmoothDamp(_currentDir, targetDir, ref _currentDirVelocity, _moveSmoothTime);
        Vector3 velocity = transform.TransformDirection(Vector3.forward * _currentDir.y + Vector3.right * _currentDir.x) * _movementSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) velocity *= 1.5f; 

        controller.Move(velocity*Time.deltaTime);

       
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "terrain") { _movementSpeed /= 2.5f; }
    }
}
