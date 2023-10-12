using UnityEngine;
using UnityEngine.UI;

public class ArrowFollow : MonoBehaviour
{
    public Transform playerTransform;
    public CharacterController playerController;
    public float offsetX = 2f;

    void Update()
    {
        // Get the player's position along the z-axis
        float playerZ = playerTransform.position.z;

        // Set the UI object's position along the z-axis
        Vector3 newPosition = transform.position;
        newPosition.z = playerZ;

        // Set the UI object's position along the x-axis based on the player's position
        float playerX = playerController.transform.position.x;
        newPosition.x = playerX + offsetX;

        transform.position = newPosition;
    }
}
