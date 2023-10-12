using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject referenceObject;
    public string playerTag = "Player";
    public string powerupTag = "Powerup";
    private float despawnTime = 20f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag) || collision.gameObject.CompareTag(powerupTag))
        {
            Vector3 spawnPos = referenceObject.transform.position;
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            Destroy(spawnedObject, despawnTime);
        }
    }
}
