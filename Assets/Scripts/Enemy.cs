using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform enemyTransform;
    public Transform EnemyTransform
    {
        get
        {
            return enemyTransform == null ? transform : enemyTransform;
        }
    }
}
