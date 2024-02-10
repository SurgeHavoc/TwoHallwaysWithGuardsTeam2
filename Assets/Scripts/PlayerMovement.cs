using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    private Rigidbody rb;
    private Vector3 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets input from the player.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 3D Vector
        moveInput = new Vector3(horizontalInput, 0, verticalInput);
        moveInput.Normalize();

        // Speed n' direction
        Vector3 moveVelocity = moveInput * moveSpeed;
        rb.velocity = moveVelocity;
    }
}
