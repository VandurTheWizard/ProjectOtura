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
            Debug.DrawLine(transform.position, transform.forward * detectionRange, Color.red, 30f); 
            if (!Physics.Raycast(transform.position, transform.forward, out ray, detectionRange) || ray.collider.gameObject.CompareTag("Player"))
            {
                status.onVision();
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
