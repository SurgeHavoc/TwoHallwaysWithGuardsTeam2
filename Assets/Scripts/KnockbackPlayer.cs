using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPlayer : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.2f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;

            CharacterController playerController = collision.gameObject.GetComponent<CharacterController>();
            if(playerController != null)
            {
                StartCoroutine(DoKnockback(playerController, knockbackDirection));
            }
        }
    }

    private System.Collections.IEnumerator DoKnockback(CharacterController controller, Vector3 direction)
    {
        float timer = 0f;

        while(timer < knockbackDuration)
        {
            controller.Move(direction * knockbackForce * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
