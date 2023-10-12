using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public GameObject particlePrefab;
    public float particleDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            // Generate particle effect
            GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);

            // Destroy particle effect after specified duration
            Destroy(particle, particleDuration);
        }
    }
}
