using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public string foodTag; // the tag used for food objects
    public string powerupTag; // the tag used for powerup objects
    public AudioClip foodCollisionSound; // the sound to play on food collision
    public AudioClip powerupCollisionSound; // the sound to play on powerup collision

    private AudioSource audioSource;

    private void Start()
    {
        // get the AudioSource component from this object
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check if the collided object has the foodTag
        if (collision.gameObject.CompareTag("food"))
        {
            // play the food collision sound
            audioSource.PlayOneShot(foodCollisionSound);
        }
        // check if the collided object has the powerupTag
        else if (collision.gameObject.CompareTag("Powerup"))
        {
            // play the powerup collision sound
            audioSource.PlayOneShot(powerupCollisionSound);
        }
    }
}
