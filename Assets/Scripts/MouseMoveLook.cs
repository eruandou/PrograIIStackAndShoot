using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveLook : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 100f;

    [SerializeField] private Transform player;

    float rotationX = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;        

    }

   
    void Update()
    {
        CheckMouseInput();
    }



    private void CheckMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        
    }



}
