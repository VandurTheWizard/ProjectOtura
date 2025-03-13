using System.Collections;
using UnityEngine;

public class EnemiesSeeBack : MonoBehaviour
{

    public float detectionRange = 10f;

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
        RaycastHit ray;

        if (other.gameObject.CompareTag("Player"))
        {
            if (!Physics.Raycast(transform.position, transform.forward, out ray, detectionRange) || ray.collider.gameObject.CompareTag("Player"))
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
                    StartCoroutine(isEndedAttack());
                }

            }
            else
            {
                status.onPatroll();
            }
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
    }
}

