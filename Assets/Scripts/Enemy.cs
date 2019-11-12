using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform enemyTransform;
    public Transform EnemyTransform
    {
        get
        {
            return enemyTransform == null ? transform : enemyTransform;
        }
    }

    public event Action<Enemy> Remove = delegate { };

    private void Start()
    {
        GetComponent<IHealth>().Die += OnDeath;
    }

    private void OnDeath()
    {
        Remove(this);
        GetComponent<IHealth>().Die -= OnDeath;
    }
}
