using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticWeapon : Weapon
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float launchAngle = 70f;

    public override void Shoot(Enemy enemy)
    {
        Vector3 startPosition = transform.position;
        GameObject projectile = Instantiate(projectilePrefab, startPosition, Quaternion.identity);

        Vector3 projectileXZPos = new Vector3(projectile.transform.position.x, 0.0f, projectile.transform.position.z);
        Vector3 targetXZPos = new Vector3(enemy.transform.position.x, 0.0f, enemy.transform.position.z);
        
        projectile.transform.LookAt(targetXZPos);

        // shorthands for the formula
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(launchAngle * Mathf.Deg2Rad);
        float H = enemy.transform.position.y - projectile.transform.position.y;

        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
        float Vy = tanAlpha * Vz;

        // create the velocity vector in local space and get it in global space
        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = projectile.transform.TransformDirection(localVelocity);

        // launch the object by setting its initial velocity
        projectile.GetComponent<Rigidbody>().velocity = globalVelocity;
    }
}
