using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdateBase : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private HealthBase hbase;

    private int currentHealth = 0;
    private int currentMaxHealth = 0;

    private void Awake()
    {
        hbase = FindObjectOfType<HealthBase>();
        hbase.OnHealthPCTChanged += HandleHealthPCTChanged;
        hbase.OnMaxHealthChanged += HandleMaxHealthChanged;
    }

    private void HandleHealthPCTChanged(int health)
    {
        currentHealth = health;
    }

    private void HandleMaxHealthChanged(int health)
    {
        currentHealth = health;
        currentMaxHealth = health;
    }

    private void Update()
    {
        text.text = $"Baselife: {currentHealth}/{currentMaxHealth}";
    }

    private void OnDestroy()
    {
        hbase.OnHealthPCTChanged -= HandleHealthPCTChanged;
        hbase.OnMaxHealthChanged -= HandleMaxHealthChanged;
    }
}
