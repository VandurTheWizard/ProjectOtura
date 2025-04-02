using UnityEngine;
using UnityEngine.AI;

public class VisibleGoingToBacj : MonoBehaviour, Visible
{
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public bool onVisible()
    {
        Vector3 destination = transform.position + transform.forward * -1;
        Vector3 vision = GameObject.FindGameObjectWithTag("Player").transform.position;
        agent.SetDestination(destination);
        return true;

    }
}
