using UnityEngine;
using UnityEngine.AI;

public class RandomPatrollMovement : MonoBehaviour, Patroll
{
    public float searchRadius = 10f;
    public float distanceDiference = 2;

    private NavMeshAgent agent;
    private Vector3 destination;

    private Vector3 lastPosition = new Vector3(0, 0, 0);
    private float distance = 0.0001f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;
    }


    private Vector3 GetRandomNavMeshPosition(Vector3 origin, float radius)
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

    private void MoveToRandomPosition()
    {
        Vector3 randomPosition = GetRandomNavMeshPosition(transform.position, searchRadius);
        if (randomPosition != Vector3.zero)
        {
            destination = randomPosition;
        }
    }

    public bool onPatroll(bool isPlayerFound)
    {
        if (Vector3.Distance(transform.localPosition, destination) < distanceDiference || isPlayerFound || isWallTouch(transform.position))
        {
            MoveToRandomPosition();
            agent.SetDestination(destination);
        }

        return false;
    }

    public bool isWallTouch(Vector3 vector)
    {
        Debug.Log(Vector3.Distance(lastPosition, vector) * Time.deltaTime);

        if (Vector3.Distance(lastPosition, vector) * Time.deltaTime < distance * Time.deltaTime)
        {
            lastPosition = vector;
            return true;
        }
        else
        {
            lastPosition = vector;
            return false;
        }
    }
}
