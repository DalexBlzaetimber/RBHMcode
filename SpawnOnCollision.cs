using UnityEngine;

public class SpawnOnCollision : MonoBehaviour
{
    public GameObject objectToSpawn;
    public string playerTag = "Player";
    public string ballTag = "ball";
    private float despawnTime = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag) || collision.gameObject.CompareTag(ballTag))
        {
            Vector3 spawnPos = collision.contacts[0].point;
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            Destroy(spawnedObject, despawnTime);
        }
    }
}
