using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool isTowerUpgradable;
    private bool isTowerSellable;

    private Tower selectedTower;
    private Camera mainCamera;

    public event Action<bool> OnBuyableBallistic = delegate { };
    public event Action<bool> OnBuyableRocket = delegate { };
    public event Action<bool> OnBuyableBlast = delegate { };

    public event Action<bool> OnTowerUpgradeable = delegate { };
    public event Action<bool> OnTowerSellable = delegate { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        isBallisticBuyable = true;
        isRocketBuyable = true;
        isBlastBuyable = true;

        isTowerUpgradable = false;
        isTowerSellable = false;

        mainCamera = Camera.main;

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

    public void OnTowerUpgrade()
    {
        if (selectedTower != null)
        {
            selectedTower.Upgrade();
        }
    }

    public void OnTowerSell()
    {
        if (selectedTower != null)
        {
            Destroy(selectedTower.gameObject);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
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

        if ((isTowerUpgradable && selectedTower == null) || (selectedTower != null && ((isTowerUpgradable & money.MoneyAmount < selectedTower.GetUpgradeCost()) || (!isTowerUpgradable & money.MoneyAmount > selectedTower.GetUpgradeCost()))))
        {
            isTowerUpgradable = !isTowerUpgradable;
            OnTowerUpgradeable(isTowerUpgradable);
        }

        if ((isTowerSellable && selectedTower == null) || (!isTowerSellable && selectedTower != null))
        {
            isTowerSellable = !isTowerSellable;
            OnTowerSellable(isTowerSellable);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tower")
                {
                    selectedTower = hit.transform.gameObject.GetComponentInParent<Tower>();
                }
                Debug.Log(hit.collider.tag);
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
            }
        }
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnPauseClick()
    {
        Time.timeScale = 0f;
    }

    public void OnPlayClick()
    {
        Time.timeScale = 1f;
    }

    public void OnSpeedPlayClick()
    {
        Time.timeScale = 2f;
    }

}
