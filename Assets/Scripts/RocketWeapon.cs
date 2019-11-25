using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : Weapon
{
    [SerializeField]
    private GameObject projectilePrefab;

    public override void Shoot(Enemy enemy)
    {
        Vector3 startPosition = transform.position;
        GameObject projectile = Instantiate(projectilePrefab, startPosition, Quaternion.identity);

        projectile.transform.LookAt(enemy.EnemyTransform.position);

        Vector3 shoot = (enemy.EnemyTransform.position - startPosition).normalized;

        projectile.GetComponent<Rigidbody>().AddForce(shoot * 500.0f);
    }
}
