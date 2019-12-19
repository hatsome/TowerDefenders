using System;
using UnityEngine;

public class AttackBase : MonoBehaviour
{

    public event Action<int> ApplyDamage = delegate { };

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Enemy>() != null)
        {
            ApplyDamage(10);
            Destroy(other.gameObject);
            Debug.Log("Collision detected");
        }        
    }
}
