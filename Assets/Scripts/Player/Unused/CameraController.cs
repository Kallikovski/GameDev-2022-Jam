using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseSensetivity = 200;
    private float xRotation = 0f;
    private new Camera camera;
    private void Start()
    {
        camera = Camera.main;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40f, 40f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }
}
