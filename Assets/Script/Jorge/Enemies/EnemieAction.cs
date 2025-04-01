using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemieAction : MonoBehaviour, EnemiesStatus
{
    private NavMeshAgent agent;
    private Vector3 destination;

    private bool stay = false;    
    private bool isPlayerFound = false;

    private Patroll patroll;
    private Visible visible;
    private Attack attack;
    private Coroutine coroutine;

  [SerializeField]  private int status = 2;
    private const int ATTACK = 0;
    private const int VISION = 1;
    private const int PATROLL = 2;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        attack = GetComponent<Attack>();
        patroll = GetComponent<Patroll>();
        visible = GetComponent<Visible>();
    }

    private void Update()
    {
        if (isStay())
            return;

        switch (status)
        {
            case ATTACK:
                isPlayerFound = true;
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
    public void onStay(int time)
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        animator.Play("Idle");
        destination = transform.position;
        agent.SetDestination(destination);
        stay = true;
        coroutine = StartCoroutine(StopStay(time));
    }

    public bool isStay()
    {
        return stay;
    }

    private IEnumerator StopStay(int time)
    {
        yield return new WaitForSeconds(time);
        stay = false;
        animator.Play("Walking");

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

    public void onAttack()
    {
        status = ATTACK;
    }
}
