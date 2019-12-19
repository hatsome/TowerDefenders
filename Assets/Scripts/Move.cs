using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField]
    private PositionPath[] firstPosition;
    [SerializeField]
    private TargetPosition target;

    private NavMeshAgent agent;
    private bool hasFirstPosition = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        firstPosition = FindObjectsOfType<PositionPath>();
        target = FindObjectOfType<TargetPosition>();
        if (firstPosition.Length == 0)
        {
            hasFirstPosition = false;
            agent.SetDestination(target.transform.position);
        }
        else
        {
            int index = Random.Range(0, firstPosition.Length);
            agent.SetDestination(firstPosition[index].transform.position);
        }
    }

    private void Update()
    {
        if (agent.remainingDistance <= 0.2f & hasFirstPosition)
        {
            hasFirstPosition = false;
            agent.SetDestination(target.transform.position);
        }
    }
}
