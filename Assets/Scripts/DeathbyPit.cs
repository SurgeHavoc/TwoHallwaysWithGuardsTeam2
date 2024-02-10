using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathbyPit : MonoBehaviour
{
    // Upon touching an object of death, player shall perish horribly.
    void OnCollisionEnter(Collision collision)
    {
        // If more than one object, check using switch.
        if(collision.gameObject.CompareTag("LavaPit"))
        {
            Die();
        }

        void Die()
        {
            Destroy(this.gameObject);
            RestartGame();
        }

        void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
