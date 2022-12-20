using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidFollower : MonoBehaviour
{
    public Transform target; // The target player to follow
    public float speed = 5f; // The speed at which the Boids will move
    public float collisionRadius = 0.5f; // The radius to use for collision detection
    [SerializeField] private List<Transform> otherBoids; // A list of the other Boid followers

    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            otherBoids.Add(transform.GetChild(i).transform);
        }
    }

    // A function to detect and avoid collisions with other Boids and the player
    private void AvoidCollision()
    {
        // Check for collisions with other Boids
        foreach (Transform boid in otherBoids)
        {
            // Ignore the current Boid
            if (boid == transform)
            {
                continue;
            }

            // Check if the current Boid is too close to the other Boid
            Vector3 direction = boid.position - transform.position;
            if (direction.magnitude < collisionRadius)
            {
                // Move away from the other Boid
                transform.position = transform.position - direction;
            }
        }

        // Check for collision with the player
        Vector3 playerDirection = target.position - transform.position;
        if (playerDirection.magnitude < collisionRadius)
        {
            // If the Boids and player are already overlapped, move the Boids a small distance away from the player in a random direction
            if (playerDirection.magnitude == 0)
            {
                transform.position = transform.position + Random.insideUnitSphere * collisionRadius;
            }
            else
            {
                // Move away from the player
                transform.position = transform.position - playerDirection;
            }
        }
    }

    void Update()
    {
        // Move towards the target player
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Avoid collisions with other Boids and the player
        AvoidCollision();
    }
}
