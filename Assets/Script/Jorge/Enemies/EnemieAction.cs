using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemieAction : MonoBehaviour, EnemiesStatus
{
    public float searchRadius = 10f; 
    public float distanceDiference = 2;

    private NavMeshAgent agent;
    private Vector3 destination;

    private bool stay = false;
    private float stayTime = 2f;
    
    private bool isPlayerFound = true;


    private int status = 2;
    private const int ATTACK = 0;
    private const int VISION = 1;
    private const int PATROLL = 2;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToRandomPosition();
    }

    private void Update()
    {
        if (isStay())
            return;

        switch (status)
        {
            case ATTACK:
                
                break;
            case VISION:
                movementOnPlayer();
                break;
            case PATROLL:
                movementOnPatroll();
                break;
        }

    }

    public void MoveToRandomPosition()
    {
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


    public void onAttack()
    {
       status = ATTACK;
    }

    public void onStay()
    {
        destination = transform.position;
        agent.SetDestination(destination);
        stay = true;
        StartCoroutine(StopStay());
    }

    public bool isStay()
    {
        return stay;
    }

    private IEnumerator StopStay()
    {
        yield return new WaitForSeconds(stayTime);
        stay = false;

    }

    public void onVision()
    {
        status = VISION;
    }

    public void onPatroll()
    {
        status = PATROLL;
       
    }

    private void movementOnPlayer()
    {
        isPlayerFound = true;
        Vector3 destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 vision = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.LookAt(vision);
        agent.SetDestination(destination);
    }

    private void movementOnPatroll()
    {
        if (Vector3.Distance(transform.localPosition, destination) < distanceDiference || isPlayerFound)
        {
            isPlayerFound = false;
            MoveToRandomPosition();
            agent.SetDestination(destination);
        }
    }

    public bool isPlayerVisible()
    {
        return isPlayerFound;
    }
}
