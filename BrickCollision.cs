using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("boarder"))
        {
            Destroy(gameObject); // destroy the brick object
        }
    }
}
