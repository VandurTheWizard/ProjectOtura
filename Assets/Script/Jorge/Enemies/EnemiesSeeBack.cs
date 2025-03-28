using System.Collections;
using UnityEngine;

public class EnemiesSeeBack : MonoBehaviour
{

    public float detectionRange = 10f;

    private Coroutine coroutine;
    private bool isPlayerVisible  = false;

    private BoxCollider boxCollider;
    private EnemiesStatus status;
    private CompatibleSeeBack seeBack;

    private void Start()
    {
        seeBack = transform.parent.GetComponent<CompatibleSeeBack>();
        status = transform.parent.GetComponent<EnemiesStatus>();
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.center = new Vector3(0, 0, detectionRange / 2);
        boxCollider.size = new Vector3(5, 2, detectionRange);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (Physics.Raycast(transform.parent.transform.position, transform.parent.transform.forward , detectionRange))
            {
                RaycastHit[] hits = Physics.RaycastAll(transform.parent.transform.position, transform.parent.transform.forward, detectionRange);
                if (CheckIfPlayerFirst(hits))
                {

                    if (other.gameObject.GetComponent<InvisibleSpell>().isVisible)
                    {
                        isPlayerVisible = true;
                        status.onVision();
                    }
                    else
                    {
                        isPlayerVisible = false;
                        status.onPatroll();
                    }
                }
                else
                {
                    comprobeIfIsAttack();
                }

            }
            else
            {
                if (other.gameObject.GetComponent<InvisibleSpell>().isVisible)
                { 
                    isPlayerVisible = true;
                    status.onVision();
                }
                else
                {
                    isPlayerVisible = false;
                    status.onPatroll();
                }
            }

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            comprobeIfIsAttack();
        }
    }

    private IEnumerator isEndedAttack()
    {
        while (!seeBack.isEnded())
        {
            yield return new WaitForSeconds(0.01f);
        }
        seeBack.resetEnded();
        isPlayerVisible = false;
        status.onPatroll();
        coroutine = null;
    }

    private void comprobeIfIsAttack()
    {
        if (isPlayerVisible)
        {
            if (seeBack.isEnded())
            {
                seeBack.resetEnded();
                isPlayerVisible = false;
                status.onPatroll();
            }
            else
            {
                status.onAttack();
                if (coroutine == null)
                    coroutine = StartCoroutine(isEndedAttack());
            }

        }
        else
        {
            status.onPatroll();
        }
    }

     private bool CheckIfPlayerFirst(RaycastHit[] hits)
    {
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
            else if (hit.collider.CompareTag("Wall"))
            {
                return false;
            }
        }

        return false;
    }
}



