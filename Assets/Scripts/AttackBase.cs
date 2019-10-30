using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{

    public event Action<int> ApplyDamage = delegate { };

    private void OnCollisionEnter(Collision other)
    {
        ApplyDamage(10);
        Destroy(other.gameObject);
        Debug.Log("Collision detected");
    }
}
