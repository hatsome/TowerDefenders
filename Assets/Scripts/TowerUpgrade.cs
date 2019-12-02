using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField]
    private Money builMoney;

    [SerializeField]
    private Money money;

    [SerializeField]
    private int maxHealth;

    private Tower parent;

    public virtual void Initialize(Tower tower)
    {
        parent = tower;
        money.Decrease(builMoney.MoneyAmount);
    }
}
