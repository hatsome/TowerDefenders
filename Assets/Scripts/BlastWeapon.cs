using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWeapon : Weapon
{
    [SerializeField]
    SphereCollider targetSphere;

    public override void Shoot(Enemy enemy)
    {
        GameObject blast = new GameObject();
        blast.transform.position = transform.position;
        SphereCollider col = blast.AddComponent<SphereCollider>();
        col.radius = targetSphere.radius;
        col.isTrigger = true;
        blast.tag = "Projectile";
    }
}
