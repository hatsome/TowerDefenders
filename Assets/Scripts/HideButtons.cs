using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButtons : MonoBehaviour
{
    [SerializeField]
    private Button buttonUpgrade;

    [SerializeField]
    private Button buttonSell;


    private void Start()
    {
        GameManager.Instance.OnTowerUpgradeable += HandleUpgradeable;
        GameManager.Instance.OnTowerSellable += HandleSellable;
    }

    private void HandleUpgradeable(bool isActive)
    {
        buttonUpgrade.gameObject.SetActive(isActive);
    }

    private void HandleSellable(bool isActive)
    {
        buttonSell.gameObject.SetActive(isActive);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnTowerUpgradeable -= HandleUpgradeable;
        GameManager.Instance.OnTowerSellable -= HandleSellable;
    }
}
