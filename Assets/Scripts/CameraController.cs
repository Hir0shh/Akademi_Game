using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float xRotation = 0.0f;
    public float mouseSensitivity = 500f;
    public GameObject oyuncu;


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        oyuncu.transform.Rotate(Vector3.up * mouseX);
        
    }
}
