using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallScript : MonoBehaviour
{
    public float speed = 10f; // Speed of the ball
    public AudioClip normalCollisionClip;
    public AudioClip floorCollisionClip;
    private AudioSource audioSource;
    private Rigidbody rb; // Reference to the Rigidbody component
    private Vector3 startPosition; // Starting position of the ball
    private float returnTimer = 0f; // Timer for returning the ball to the start position
    private bool ballReturned = false; // Whether the ball has been returned to the start position
    private float returnDelay = 3f; // Delay before returning the ball to the start position
    private GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        // Get the current velocity of the ball
        Vector3 velocity = rb.velocity;

        // Set the x-component of the velocity to 0, so the ball only moves along the y and z-axis
        velocity.x = 0;

        // Set the velocity of the ball to the modified velocity
        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            // Ignore collision with food items
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        if (collision.gameObject.CompareTag("ball"))
        {
            // Ignore collision with food items
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        // Check if the ball has collided with the floor object
        if (collision.gameObject.CompareTag("floor"))
        {
            // Set the velocity of the ball to 0
            rb.velocity = Vector3.zero;

            // Return the ball to the start position and reset the timer
            transform.position = startPosition;
            returnTimer = 0f;
            ballReturned = true;

            // Play the floor collision audio clip
            audioSource.clip = floorCollisionClip;
            audioSource.Play(); ;

            // Decrease the number of lives by 1 in the GameManager script
            if (gameManager != null && ballReturned == true)
            {
                gameManager.BallLost();
            }
        }
        else if (collision.gameObject.CompareTag("brick"))
        {
            // Get the contact point of the collision
            ContactPoint contact = collision.contacts[0];

            // Calculate the direction of the bounce
            Vector3 direction = Vector3.Reflect(rb.velocity.normalized, contact.normal);

            // Set the x-component of the direction to 0, so the ball only bounces along the y and z-axis
            direction.x = 0;

            // Set the velocity of the ball to the direction multiplied by the speed
            rb.velocity = direction * speed;
            // Destroy the brick object and update the GameManager script
            Destroy(collision.gameObject);
            gameManager.BrickDestroyed();


            // Play the normal collision audio clip
            audioSource.clip = normalCollisionClip;
            audioSource.Play();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Get the contact point of the collision
            ContactPoint contact = collision.contacts[0];

            gameManager.score += 5;
            gameManager.scoreText.text = "" + gameManager.score;

            // Calculate the direction of the bounce
            Vector3 direction = Vector3.Reflect(rb.velocity.normalized, contact.normal);

            // Set the x-component of the direction to 0, so the ball only bounces along the y and z-axis
            direction.x = 0;

            // Set the velocity of the ball to the direction multiplied by the speed
            rb.velocity += direction * speed;

            // Play the normal collision audio clip
            audioSource.clip = normalCollisionClip;
            audioSource.Play();
        }
        else
        {
            // Get the contact point of the collision
            ContactPoint contact = collision.contacts[0];

            // Calculate the direction of the bounce
            Vector3 direction = Vector3.Reflect(rb.velocity.normalized, contact.normal);

            // Set the x-component of the direction to 0, so the ball only bounces along the y and z-axis
            direction.x = 0;

            // Set the velocity of the ball to the direction multiplied by the speed
            rb.velocity = direction * speed;

            gameManager.score += 1;
            gameManager.scoreText.text = "" + gameManager.score;

            // Play the normal collision audio clip
            audioSource.clip = normalCollisionClip;
            audioSource.Play();
        }
    }

}


