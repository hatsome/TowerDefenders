using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private TowerUpgrade[] upgrades;

    [SerializeField]
    private string towerName;

    [SerializeField]
    private int currentUpgradeIndex;

    [SerializeField]
    private TowerUpgrade currentTowerUpgrade;

    // For testing
    private void Start()
    {
        UpgradeTo(0);
    }

    public virtual void Initialize(Vector2 position)
    {
        transform.position = position;

        UpgradeTo(0);
    }

    public int GetUpgradeCost()
    {
        if (currentUpgradeIndex + 1 < upgrades.Length)
        {
            return upgrades[currentUpgradeIndex + 1].GetCost().MoneyAmount;
        }
        return int.MaxValue;
    }

    public void Upgrade()
    {
        UpgradeTo(currentUpgradeIndex + 1);
    }

    private void UpgradeTo(int index)
    {
        if (index >= 0 && index < upgrades.Length)
        {
            currentUpgradeIndex = index;

            if (currentTowerUpgrade != null)
            {
                Destroy(currentTowerUpgrade.gameObject);
            }

            currentTowerUpgrade = Instantiate(upgrades[currentUpgradeIndex], transform);

            currentTowerUpgrade.Initialize(this);
        }

        Debug.Log(currentTowerUpgrade);
    }
}
