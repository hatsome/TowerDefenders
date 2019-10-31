using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField]
    private int cost;

    [SerializeField]
    private int maxHealth;

    private Tower parent;

    public virtual void Initialize(Tower tower)
    {
        parent = tower;
    }
}
