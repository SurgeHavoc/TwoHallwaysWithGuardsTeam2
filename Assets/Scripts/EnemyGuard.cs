using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGuard : MonoBehaviour
{
    // An array of waypoints to follow. Can use empty gameObjects as waypoints by adding them to the array of each enemy manually.
    public Transform[] patrolWaypoints;
    public float chaseRange = 10f;
    public float moveSpeed = 3.5f;
    public float stoppingDistance = 0.5f;
    public Transform player;

    private int currentWaypointIndex = 0;
    private bool isChasing = false;

    // Update is called once per frame
    void Update()
    {
        if(!isChasing)
        {
            Patrol();
        }
        else
        {
            ChasePlayer();
        }
    }

    // Travel around using waypoints.
    void Patrol()
    {
        if(patrolWaypoints.Length == 0)
        {
            return;
        }

        Transform currentWaypoint = patrolWaypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        transform.LookAt(currentWaypoint.position);

        if(Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % patrolWaypoints.Length;
        }
    }

    // Chase the player.
    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        transform.LookAt(player.position);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer <= stoppingDistance)
        {
            isChasing = false;
        }
    }

    // Identify player as target.
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.transform;
            isChasing = true;
        }
    }
}
