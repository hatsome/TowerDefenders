using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private TargetFinder targetFinder;

    [SerializeField]
    private float attackSpeed = 1f;

    private Weapon weapon;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        StartCoroutine(AttackEnemy());
    }

    IEnumerator AttackEnemy()
    {
        for (; ;)
        {
            Enemy enemy = targetFinder.GetNearestTarget();
            if (enemy != null)
            {
                weapon.Shoot(enemy);
            }
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
