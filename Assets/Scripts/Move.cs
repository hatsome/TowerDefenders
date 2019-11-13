using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField]
    private List<PositionPath> firstPosition;
    [SerializeField]
    private PositionPath target;

    private NavMeshAgent agent;
    private bool hasFirstPosition = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (firstPosition.Count == 0)
        {
            hasFirstPosition = false;
            agent.SetDestination(target.transform.position);
        }
        else
        {
            int index = Random.Range(0, firstPosition.Count);
            agent.SetDestination(firstPosition[index].transform.position);
        }
    }

    private void Update()
    {
        if (agent.remainingDistance <= 0.2f & hasFirstPosition)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}
