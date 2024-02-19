using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;

    bool m_IsPlayerInRange;

    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    private GameManager gM;

    Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;

            // On player enter range, play animation.
            anim.SetBool("IsAttacking", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;

            // On player exit range, stop playing animation.
            anim.SetBool("IsAttacking", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Die();
        }

        void Die()
        {
            gM.GuardDied(gameObject);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Make sure you get Animator so that the script has context as to what Animator is.
        anim = GetComponent<Animator>();
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        navMeshAgent.SetDestination(waypoints[0].position);
        anim.SetBool("IsAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            navMeshAgent.SetDestination(player.position);
        }

        if (!m_IsPlayerInRange && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
