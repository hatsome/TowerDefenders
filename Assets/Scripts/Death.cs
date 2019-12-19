using UnityEngine;

public class Death : MonoBehaviour
{

    private IHealth health;

    private void Start()
    {
        health = GetComponent<IHealth>();
        health.Die += OnDeath;
    }


    private void OnDeath()
    {
        Destroy(gameObject);
    }


    private void OnDestroy()
    {
        health.Die -= OnDeath;
    }
}
