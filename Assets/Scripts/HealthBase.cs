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

    public event Action Die = delegate { }; 

    private void Start()
    {
        attackBase = GetComponentInChildren<AttackBase>();
        attackBase.ApplyDamage += TakeDamage;

        setMaxHealth(baseProperties.GetMaxHealth());

        Debug.Log("Start");
    }
       
    public void setMaxHealth(int amount)
    {
        health = amount;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void OnDestroy()
    {
        attackBase.ApplyDamage -= TakeDamage;
    }
}
