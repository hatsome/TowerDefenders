using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int health = 10;
    
    private int maxHealth = 0;

    private Hit hit;

    public event Action Die = delegate { };
    public event Action<float> OnHealthPCTChanged = delegate { };

    private void Start()
    {
        hit = GetComponent<Hit>();
        hit.ApplyHit += TakeDamage;

        setMaxHealth(health);

        Debug.Log("Start");
    }

    public void setMaxHealth(int amount)
    {
        maxHealth = amount;
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        float currentHealthPct = (float)health / (float)maxHealth;
        OnHealthPCTChanged(currentHealthPct);
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnDestroy()
    {
        hit.ApplyHit -= TakeDamage;
    }
}
