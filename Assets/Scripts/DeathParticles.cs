using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem deathParticlePrefab;
    [SerializeField]
    private Vector3 offset;

    private IHealth health;

    private void Start()
    {
        health = GetComponent<IHealth>();
        health.Die += OnDeath;
    }


    private void OnDeath()
    {
        var deathParticle = Instantiate(deathParticlePrefab, transform.position + offset, transform.rotation);

        Destroy(deathParticle, deathParticle.duration);
    }


    private void OnDestroy()
    {
        health.Die -= OnDeath;
    }
}
