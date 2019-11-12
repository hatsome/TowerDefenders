using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    private List<Enemy> targets = new List<Enemy>();

    public Enemy GetNearestTarget()
    {
        Enemy nearest = null;

        if (targets.Count > 0)
        {
            float distance = float.MaxValue;
            for (int i = 0; i < targets.Count; i++)
            {
                Enemy enemy = targets[i];
                float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    nearest = enemy;
                }
            }
        }

        return nearest;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            targets.Add(enemy);
            enemy.Remove += OnTargetRemoved;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            targets.Remove(enemy);
            enemy.Remove -= OnTargetRemoved;
        }
    }

    private void OnTargetRemoved(Enemy enemy)
    {
        targets.Remove(enemy);
        enemy.Remove -= OnTargetRemoved;
    }
}
