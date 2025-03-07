using UnityEngine;
using UnityEngine.AI;

public class CirclePatrollMovement : MonoBehaviour, Patroll
{
    public float searchRadius = 10f;
    public float distanceDiference = 2;

    private NavMeshAgent agent;
    private Vector3 destination;

    private bool isFoundPentagrama = true;
    //private int TimePentagrama = 10;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;
    }
    public void MoveToRandomPosition()
    {
        GameObject pentagrama = GameObject.FindGameObjectWithTag("Pentagrama");
        if (pentagrama != null && isFoundPentagrama)
        {
            destination = pentagrama.transform.position;
            return;
        }


        Vector3 randomPosition = GetRandomNavMeshPosition(transform.position, searchRadius);
        if (randomPosition != Vector3.zero)
        {
            destination = randomPosition;
        }
    }

    Vector3 GetRandomNavMeshPosition(Vector3 origin, float radius)
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += origin;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return Vector3.zero;
    }


    public bool onPatroll(bool isPlayerVisible)
    {
        if (Vector3.Distance(transform.localPosition, destination) < distanceDiference || isPlayerVisible)
        {
            MoveToRandomPosition();
            agent.SetDestination(destination);
        }
        return false;
    }
}
