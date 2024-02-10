using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform pTarget; // track player
    public float distance = 5.0f;
    public float height = 2.0f;
    public float rotationSpeed = 3.0f;

    private float mouseX;

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        // Manipulation of the camera
        Quaternion rotation = Quaternion.Euler(0, mouseX, 0);
        Vector3 negDistance = new Vector3(0.0f, height, -distance);
        Vector3 position = rotation * negDistance + pTarget.position;
        transform.rotation = rotation;
        transform.position = position;
    }
}
