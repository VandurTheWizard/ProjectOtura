using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AttackWithCruz : MonoBehaviour, Attack
{
    public float damagePerSecond = 1;
    private LifeUsage life;
    private bool isAttack = true;
    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        life = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeUsage>();
    }
    public void onAttack()
    {
        if (!isAttack)
        {
            return;
        }
        going();
        life.loseLife(damagePerSecond * Time.deltaTime);
    }

    public void resetAttack()
    {
      
    }

    public bool going()
    {
        Vector3 destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 vision = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.LookAt(vision);
        agent.SetDestination(destination);
        return true;

    }
}
