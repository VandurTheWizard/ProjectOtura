using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemieAction : MonoBehaviour, EnemiesStatus
{
    public float searchRadius = 10f; 
    public float distanceDiference = 2;

    private NavMeshAgent agent;
    private Vector3 destination;

    private bool stay = false;
    private float stayTime = 2f;

    private bool handling = false;
    
    private bool isPlayerFound = true;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToRandomPosition();
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
        isPlayerFound= true;
        Vector3 destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        agent.SetDestination(destination);
    }

    public void onPatroll()
    {
        if (Vector3.Distance(transform.localPosition, destination) < distanceDiference || isPlayerFound)
        {
            
            isPlayerFound = false;
            MoveToRandomPosition();
            agent.SetDestination(destination);
        }
       
    }

    public void onHandling()
    {
        Debug.Log("Me quiero matar");
    }

    public bool isHandling()
    {
        return handling;
    }
}
