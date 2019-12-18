using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : Weapon
{
    [SerializeField]
    private GameObject projectilePrefab;

    public override void Shoot(Enemy enemy)
    {
        GameObject projectile = Instantiate(projectilePrefab, enemy.transform.position, Quaternion.identity);
        AudioManager.Instance.Play(AudioManager.SoundType.SHOT);
    }
}
