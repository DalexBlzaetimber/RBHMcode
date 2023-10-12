using UnityEngine;

public class BrickDistroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObj = collision.gameObject;
        if (collidedObj.CompareTag("brick"))
        {
            Destroy(collidedObj);
        }
    }
}