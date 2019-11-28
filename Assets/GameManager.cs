using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TowerPlacer ballisticTowerPlacer;

    [SerializeField]
    private TowerPlacer rocketTowerTowerPlacer;

    [SerializeField]
    private TowerPlacer blastTowerPlacer;

    [SerializeField]
    private int money;

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
    }

    public void OnMenuClick()
    {
        Application.Quit();
    }
}
