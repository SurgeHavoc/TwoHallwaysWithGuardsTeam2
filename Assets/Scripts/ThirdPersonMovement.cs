using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool IsWalking;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -200f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

<<<<<<< Updated upstream
=======
        // Logic to handle walking.
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        // bool isWalking = hasHorizontalInput || hasVerticalInput;
        // animator.SetBool("IsWalking", isWalking);

        if(animator.GetBool("IsWalking") == false)
        {
            animator.SetBool("IsIdle", true);
        }

        // If moving.
>>>>>>> Stashed changes
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime); // Move character controller.
            animator.SetBool("isWalking", true);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
<<<<<<< Updated upstream
=======
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        // If press Q, use attack animation;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("IsAttacking", true);
            animator.SetBool("IsIdle", true);
        }
        else if(!Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("IsAttacking", false);
>>>>>>> Stashed changes
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            UnityEngine.Debug.Log("Touch 2!");
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Lava"))
        {
            UnityEngine.Debug.Log("Touch!");
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
