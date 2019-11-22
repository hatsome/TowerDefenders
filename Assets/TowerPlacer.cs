using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField]
    GameObject towerPrefab;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Terrain")
            {
                Transform objectHit = hit.transform;

                transform.position = new Vector3(objectHit.position.x, transform.position.y, objectHit.position.z);

                Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
