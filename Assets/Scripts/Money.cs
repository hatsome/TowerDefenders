using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Money : ScriptableObject
{
    [SerializeField]
    private int moneyAmount;

    public int MoneyAmount
    {
        get
        {
            return moneyAmount;
        }
    }

    public void Initialize(int amount)
    {
        moneyAmount = amount;
    }

    public void Increase(int amount)
    {
        moneyAmount += amount;
    }

    public void Decrease(int amount)
    {
        moneyAmount -= amount;
    }
}
