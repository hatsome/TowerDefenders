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
}
