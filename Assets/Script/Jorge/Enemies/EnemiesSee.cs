using UnityEngine;

public class EnemiesSee : MonoBehaviour
{

    public float detectionRange = 10f;

    private BoxCollider boxCollider;
    private EnemiesStatus status;

    private void Start()
    {
       status =  transform.parent.GetComponent<EnemiesStatus>();
       boxCollider = GetComponent<BoxCollider>();
       boxCollider.center = new Vector3 (0, 0, detectionRange/2);
       boxCollider.size = new Vector3(5, 2, detectionRange);
    }

    private void OnTriggerStay(Collider other)
    {
        RaycastHit ray;
       
        if(other.gameObject.CompareTag("Player"))
        {
            if (!Physics.Raycast(transform.position, transform.forward, out ray, detectionRange) || ray.collider.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<InvisibleSpell>().isVisible)
                {
                    status.onVision();
                }
                else
                {
                    status.onPatroll();
                }
            }
           
        }

       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           status.onPatroll();
        }
    }
}
