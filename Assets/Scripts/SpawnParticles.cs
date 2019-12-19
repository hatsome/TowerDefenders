using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem spawnParticle;

    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(spawnParticle, transform.position, transform.rotation);
    }

}
