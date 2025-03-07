using UnityEngine;
using UnityEngine.AI;

public class VisibleGoingToPlayer : MonoBehaviour, Visible
{

    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public bool onVisible()
    {
        Vector3 destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 vision = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.LookAt(vision);
        agent.SetDestination(destination);
        return true;
    
    }
}
