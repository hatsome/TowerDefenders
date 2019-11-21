using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IHealth
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private BaseProperties baseProperties;

    private AttackBase attackBase;
    private int maxHealth = 0;

    public event Action Die = delegate { };
    public event Action<int> OnMaxHealthChanged = delegate { };
    public event Action<int> OnHealthPCTChanged = delegate { };

    private void Start()
    {
        attackBase = GetComponentInChildren<AttackBase>();
        attackBase.ApplyDamage += TakeDamage;

        setMaxHealth(baseProperties.MaxHealth);

        Debug.Log("Start");
    }
       
    public void setMaxHealth(int amount)
    {
        maxHealth = amount;
        OnMaxHealthChanged(maxHealth);
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        OnHealthPCTChanged(health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnDestroy()
    {
        attackBase.ApplyDamage -= TakeDamage;
    }
}
