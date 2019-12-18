using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField]
    private Money buildMoney;

    [SerializeField]
    private Money money;

    [SerializeField]
    private int maxHealth;

    private Tower parent;

    public virtual void Initialize(Tower tower)
    {
        parent = tower;
        money.Decrease(buildMoney.MoneyAmount);

        AudioManager.Instance.Play(AudioManager.SoundType.PLACE);
    }

    public Money GetCost()
    {
        return buildMoney;
    }

    private void OnDestroy()
    {
        money.Increase(buildMoney.MoneyAmount / 2);
    }
}
