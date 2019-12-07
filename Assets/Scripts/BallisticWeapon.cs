using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BallisticWeapon : Weapon
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float flightTime = 1.5f;

    public override void Shoot(Enemy enemy)
    {
        Vector3 startPosition = transform.position;
        GameObject projectile = Instantiate(projectilePrefab, startPosition, Quaternion.identity);

        Vector3 target = enemy.transform.position + enemy.GetComponent<NavMeshAgent>().velocity * flightTime *0.9f;
        Debug.DrawLine(startPosition, target);
        float vx = (target.x - startPosition.x) / flightTime;
        float vz = (target.z - startPosition.z) / flightTime;
        float vy = ((target.y - startPosition.y) - 0.5f * Physics.gravity.y * flightTime * flightTime) / flightTime;
        projectile.GetComponent<Rigidbody>().velocity = new Vector3(vx, vy, vz);
    }
}
