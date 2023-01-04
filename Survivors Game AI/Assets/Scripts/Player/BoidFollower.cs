using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidFollower : MonoBehaviour
{
    public Transform target; // The target player to follow
    public float speed = 5f; // The speed at which the Boid moves
    public float maxSpeed = 10f; // The maximum speed limit for the Boid
    public float stoppingDistance = 1f; // The distance at which the Boid stops following the player
    public float separationDistance = 0.5f; // The distance at which the Boid tries to separate from other Boids
    public float separationWeight = 1f; // The weight of the separation behavior (how much influence it has on the Boid's movement)
    public float smoothing = 0.5f; // The smoothing factor for the Boid's movement
    public float brakingDistance = 0.5f; // The distance at which the Boid starts braking

    private void Update()
    {
        

        // Calculate the distance between the Boid and the target player
        float distance = Vector2.Distance(transform.position, target.position);

        // If the Boid is further away than the stopping distance, move towards the player
        if (distance > stoppingDistance)
        {
            // Calculate the direction to the target player
            Vector2 direction = (target.position - transform.position).normalized;

            // Calculate the separation vector (the direction away from other Boids)
            Vector2 separationVector = CalculateSeparationVector();

            // Combine the direction to the target player and the separation vector
            Vector3 combinedVector = direction + separationVector * separationWeight;

            // Calculate the braking force if the Boid is within the braking distance
            if (distance < brakingDistance)
            {
                combinedVector *= 1 - (distance / brakingDistance);
            }

            // Calculate the speed multiplier based on the distance to the target player
            float speedMultiplier = 1 + (distance / stoppingDistance);

            // Clamp the combined vector to the maximum speed
            combinedVector = Vector3.ClampMagnitude(combinedVector, maxSpeed * speedMultiplier);

            // Interpolate between the Boid's current position and the target position using the combined vector and the smoothing factor
            transform.position = Vector2.Lerp(transform.position, transform.position + combinedVector, smoothing * Time.deltaTime);
        }
    }

    // Calculate the separation vector (the direction away from other Boids)
    Vector2 CalculateSeparationVector()
    {
        // Find all Boids within a certain distance
        Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, separationDistance);

        // Initialize the separation vector to zero
        Vector2 separationVector = Vector2.zero;

        // For each Boid found...
        foreach (Collider2D neighbor in neighbors)
        {
            // ...if it is not this Boid...
            if (neighbor.gameObject != gameObject)
            {
                // ...add a vector pointing away from the Boid to the separation vector
                separationVector += (Vector2)(transform.position - neighbor.transform.position).normalized;
            }
        }

        // Normalize the separation vector and return it
        return separationVector.normalized;
    }
}
