using UnityEngine;
using SimpleInputNamespace;

public class BBPlayerController : MonoBehaviour
{
    public float speed = 10.0f; // Speed of the paddle movement
    private CharacterController controller; // Reference to the CharacterController component

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        transform.position = new Vector3(transform.position.x, 5, transform.position.z); // Lock the paddle's Y position
    }

    private void Update()
    {
        float horizontalInput = SimpleInput.GetAxis("Horizontal"); // Get input from the horizontal axis

        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0); // Create a movement vector based on input, only using the z-axis
        moveDirection = transform.TransformDirection(moveDirection); // Transform the vector to be in the same direction as the paddle

        moveDirection *= speed; // Multiply the movement vector by the speed

        controller.Move(moveDirection * Time.deltaTime); // Move the paddle using the CharacterController component
    }
}
