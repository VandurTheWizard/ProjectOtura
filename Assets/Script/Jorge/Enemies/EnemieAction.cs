using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemieAction : MonoBehaviour, EnemiesStatus
{
    private NavMeshAgent agent;
    private Vector3 destination;

    private bool stay = false;
    private float stayTime = 2f;
    
    private bool isPlayerFound = false;

    private Patroll patroll;
    private Visible visible;
    private Attack attack;

    private int status = 2;
    private const int ATTACK = 0;
    private const int VISION = 1;
    private const int PATROLL = 2;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patroll = GetComponent<Patroll>();
        visible = GetComponent<Visible>();
        attack = GetComponent<Attack>();    
    }

    private void Update()
    {
        if (isStay())
            return;

        switch (status)
        {
            case ATTACK:
                attack.onAttack();
                break;
            case VISION:
                isPlayerFound = visible.onVisible();
                break;
            case PATROLL:
                isPlayerFound = patroll.onPatroll(isPlayerFound);
                break;
        }

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


    public bool isPlayerVisible()
    {
        return isPlayerFound;
    }
}
