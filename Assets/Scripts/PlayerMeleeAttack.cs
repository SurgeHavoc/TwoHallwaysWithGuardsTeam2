using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float knockbackForce = 15.0f;

    AudioSource HitAudio;

    // Start is called before the first frame update
    void Start()
    {
        HitAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            DoMeleeAttack();
        }
    }

    private void DoMeleeAttack()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                Vector3 knockbackDirection = (hit.collider.transform.position - transform.position).normalized;
                HitAudio.Play();

                Rigidbody enemyRigidbody = hit.collider.GetComponent<Rigidbody>();
                if(enemyRigidbody != null)
                {
                    enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
                }
            }
        }
    }
}
