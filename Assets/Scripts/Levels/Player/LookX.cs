using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    private float sensitivity;
    //private OptionsGame OptionsGamePlay;
    private float lastSensitivity;
    private void Start()
    {
     
    }
    void Update()
    {
        if (OptionsGamePlay.sensativity != sensitivity)
        {
            sensitivity = OptionsGamePlay.sensativity;
            //Debug.Log("Times in to LookX sensativity");
        }

    
        float mouseX = Input.GetAxis("Mouse X");
        //Debug.Log("mouse x = " + _mouseX);
        Vector3 rotation = transform.localEulerAngles;
        rotation.y += mouseX * sensitivity + rotationSpeed * mouseX;  // Rotation around the vertical (Y) axis
        transform.localEulerAngles = rotation;
    }
}
