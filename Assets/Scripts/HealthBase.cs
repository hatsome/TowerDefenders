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
    public event Action<float> OnHealthPCTChanged = delegate { };

    private void Start()
    {
        attackBase = GetComponentInChildren<AttackBase>();
        attackBase.ApplyDamage += TakeDamage;

        setMaxHealth(baseProperties.GetMaxHealth());

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
        attackBase.ApplyDamage -= TakeDamage;
    }
}
