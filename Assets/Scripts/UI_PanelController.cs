using UnityEngine;

public class UI_PanelController : MonoBehaviour
{
    public void OnPlaceBallisticTower()
    {
        GameManager.Instance.OnPlaceBallisticTower();
    }

    public void OnPlaceRocketTower()
    {
        GameManager.Instance.OnPlaceRocketTower();
    }

    public void OnPlaceBlastTower()
    {
        GameManager.Instance.OnPlaceBlastTower();
    }

    public void OnTowerUpgrade()
    {
        GameManager.Instance.OnTowerUpgrade();
    }

    public void OnTowerSell()
    {
        GameManager.Instance.OnTowerSell();
    }


    public void OnMenuClick()
    {
        GameManager.Instance.OnMenuClick();
    }

    public void OnPauseClick()
    {
        GameManager.Instance.OnPauseClick();
    }

    public void OnPlayClick()
    {
        GameManager.Instance.OnPlayClick();
    }

    public void OnSpeedPlayClick()
    {
        GameManager.Instance.OnSpeedPlayClick();
    }
}
