using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour
{

    public float mouseSensivity = 6f;
    public Slider mouseSensivitySetting;
    private float defaultMouseSensivity;
    [SerializeField] private float _mousePitch = 0f;
    [SerializeField] [Range(0.0f, 0.5f)] private float _mouseSmoothTime = 0.03f;

    public Transform playerBody;

    private Vector2 _currentMouseDelta = Vector2.zero;
    private Vector2 _currentMouseDeltaVelocity = Vector2.zero;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        defaultMouseSensivity = mouseSensivity;
        mouseSensivity = defaultMouseSensivity * mouseSensivitySetting.value / mouseSensivitySetting.maxValue;
    }

   
    void Update()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetMouseDelta, ref _currentMouseDeltaVelocity, _mouseSmoothTime);
       
        _mousePitch -= _currentMouseDelta.y * mouseSensivity;
        _mousePitch = Mathf.Clamp(_mousePitch, -90f, 90f);
        if (Time.timeScale == 1)
        {
            transform.localRotation = Quaternion.Euler(_mousePitch, 0f, 0f);

            playerBody.Rotate(Vector3.up * _currentMouseDelta.x * mouseSensivity);
        }
    }
    public void MouseSensivityChange()
    {
        mouseSensivity = defaultMouseSensivity * mouseSensivitySetting.value/mouseSensivitySetting.maxValue;
    }
}
