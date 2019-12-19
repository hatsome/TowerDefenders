using System;
using UnityEngine;

public class WeakHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int health = 10;

    [SerializeField]
    private Money money;

    [SerializeField]
    private int bonusMoney = 50;
    
    private int maxHealth = 0;

    private Hit hit;

    public event Action Die = delegate { };
    public event Action<int> OnMaxHealthChanged = delegate { };
    public event Action<int> OnHealthPCTChanged = delegate { };

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
        OnMaxHealthChanged(maxHealth);
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        OnHealthPCTChanged(health);
        if (health <= 0)
        {
            money.Increase(bonusMoney);
            Die();
        }
    }

    private void OnDestroy()
    {
        hit.ApplyHit -= TakeDamage;
    }
}
