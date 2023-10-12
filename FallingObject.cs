using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 5f;

    private bool isFalling = false;

    private void Update()
    {
        if (isFalling)
        {
            // Move the object downwards at a constant speed
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor") || collision.gameObject.CompareTag("Player"))
        {
            // Destroy the object if it collides with the floor or player
            Destroy(gameObject);
        }
        else if (!isFalling)
        {
            // Start falling if the object collides with anything else
            isFalling = true;

            // Start the countdown to destroy the object after its lifetime has expired
            Invoke("DestroyObject", lifeTime);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
