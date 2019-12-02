using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisbaleButtons : MonoBehaviour
{
    [SerializeField]
    private Button buttonBallistic;

    [SerializeField]
    private Button buttonRocket;

    [SerializeField]
    private Button buttonBlast;

    private void Start()
    {
        GameManager.Instance.OnBuyableBallistic += HandleBuyableBallistic;
        GameManager.Instance.OnBuyableRocket += HandleBuyableRocket;
        GameManager.Instance.OnBuyableBlast += HandleBuyableBlast;
    }

    private void HandleBuyableBallistic(bool isActive)
    {
        buttonBallistic.interactable = isActive;
    }

    private void HandleBuyableRocket(bool isActive)
    {
        buttonRocket.interactable = isActive;
    }

    private void HandleBuyableBlast(bool isActive)
    {
        buttonBlast.interactable = isActive;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnBuyableBallistic -= HandleBuyableBallistic;
        GameManager.Instance.OnBuyableRocket -= HandleBuyableRocket;
        GameManager.Instance.OnBuyableBlast -= HandleBuyableBlast;
    }
}
