using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player’s transform
    public float speed = 1f; // Movement speed

    void Update()
    {
        FollowPlayer();
        RotateTowardsPlayer();
    }

    void FollowPlayer()
    {
        // Move towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }

    void RotateTowardsPlayer()
    {
        // Find the direction to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Calculate the angle only on the Y-axis
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Rotate only around the Y-axis
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
