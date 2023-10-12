using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow
    public float distance = 10f; // The distance from the target
    public float height = 5f; // The height above the target

    private Vector3 offset; // The initial offset between the camera and the target

    private void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate the target position with the offset
        Vector3 targetPos = target.position + offset;

        // Only move the camera on the y and z axis
        targetPos.x = transform.position.x;

        // Move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f);
    }
}

