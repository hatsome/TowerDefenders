using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private TowerPlacer ballisticTowerPlacer;

    [SerializeField]
    private TowerPlacer rocketTowerTowerPlacer;

    [SerializeField]
    private TowerPlacer blastTowerPlacer;

    [SerializeField]
    private Money money;

    [SerializeField]
    private int startMoney = 800;

    [SerializeField]
    private Money costBallistic;

    [SerializeField]
    private Money costRocket;

    [SerializeField]
    private Money costBlast;

    private bool isBallisticBuyable;
    private bool isRocketBuyable;
    private bool isBlastBuyable;

    public event Action<bool> OnBuyableBallistic = delegate { };
    public event Action<bool> OnBuyableRocket = delegate { };
    public event Action<bool> OnBuyableBlast = delegate { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        isBallisticBuyable = true;
        isRocketBuyable = true;
        isBlastBuyable = true;

        money.Initialize(startMoney);

        DontDestroyOnLoad(gameObject);
    }

    public void OnPlaceBallisticTower()
    {
        Instantiate(ballisticTowerPlacer.gameObject);
    }

    public void OnPlaceRocketTower()
    {
        Instantiate(rocketTowerTowerPlacer.gameObject);
    }

    public void OnPlaceBlastTower()
    {
        Instantiate(blastTowerPlacer.gameObject);
    }

    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if ((isBallisticBuyable & money.MoneyAmount < costBallistic.MoneyAmount) | (!isBallisticBuyable & money.MoneyAmount > costBallistic.MoneyAmount))
        {
            isBallisticBuyable = !isBallisticBuyable;
            OnBuyableBallistic(isBallisticBuyable);
        }

        if ((isRocketBuyable & money.MoneyAmount < costRocket.MoneyAmount) | (!isRocketBuyable & money.MoneyAmount > costRocket.MoneyAmount))
        {
            isRocketBuyable = !isRocketBuyable;
            OnBuyableRocket(isRocketBuyable);
        }

        if ((isBlastBuyable & money.MoneyAmount < costBlast.MoneyAmount) | (!isBlastBuyable & money.MoneyAmount > costBlast.MoneyAmount))
        {
            isBlastBuyable = !isBlastBuyable;
            OnBuyableBlast(isBlastBuyable);
        }
    }

    public void OnMenuClick()
    {
        Application.Quit();
    }
}
