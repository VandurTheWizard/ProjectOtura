using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemiesSee : MonoBehaviour
{
    private Transform player;

    [Header("Rango de detección")]
    public float detectionRange = 10f;
    public float visionAngle = 60f;
    public LayerMask obstacleLayer;

    private EnemiesStatus status;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        status = GetComponent<EnemiesStatus>();
    }
    void Update()
    {
        if (status.isStay())
            return;

        if (PlayerInSight())
        {
            status.onVision();
        }
        else
        {
            status.onPatroll();
        }
    }

    bool PlayerInSight()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > detectionRange)
            return false;

        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer.normalized);

        if (angleToPlayer > visionAngle / 2f)
        {
            if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer))
            {
                return false;
            }
        }
        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Vector3 leftLimit = Quaternion.Euler(0, -visionAngle / 2, 0) * transform.forward * detectionRange;
        Vector3 rightLimit = Quaternion.Euler(0, visionAngle / 2, 0) * transform.forward * detectionRange;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + leftLimit);
        Gizmos.DrawLine(transform.position, transform.position + rightLimit);
    }
}
