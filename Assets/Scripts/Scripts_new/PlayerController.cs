using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Transform cam;
    public float lookSensivity;
    public float maxXRot;
    public float minXRot;
    private float curXRot;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(Cursor.lockState==CursorLockMode.Locked)
            
        Look();

    }
    
    void Look()
    {
        float x = Input.GetAxis("Mouse X") * lookSensivity;
        float y = Input.GetAxis("Mouse Y") * lookSensivity;

        transform.eulerAngles += Vector3.up * x;
        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);
        cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f);


    }
}
