using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoneyText : MonoBehaviour
{
    [SerializeField]
    private Text textfeldMoney;

    [SerializeField]
    private Money money;

    // Update is called once per frame
    void Update()
    {
        textfeldMoney.text = $"Money: {money.MoneyAmount}";
    }
}
