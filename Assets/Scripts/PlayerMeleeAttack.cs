using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float knockbackForce = 15.0f; // Knockback force.
    public float raycastOffset = -2.0f; // Offset to bring the initial position of the raycast back.

    AudioSource HitAudio;

    // Start is called before the first frame update
    void Start()
    {
        HitAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Press Q to use melee.
        if(Input.GetKeyDown(KeyCode.Q))
        {
            DoMeleeAttack();
        }
    }

    private void DoMeleeAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.forward * raycastOffset, transform.forward, out hit, 1.5f))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                Vector3 knockbackDirection = (hit.collider.transform.position - transform.position).normalized; // Set knockback direction to the direction that the player is facing.
                HitAudio.Play();

                Rigidbody enemyRigidbody = hit.collider.GetComponent<Rigidbody>();
                if(enemyRigidbody != null)
                {
                    // Add knockback force to enemy.
                    enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
                }
            }
        }
    }
}
