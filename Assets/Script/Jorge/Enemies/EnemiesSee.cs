using UnityEngine;
using UnityEngine.AI;

public class EnemiesSee : MonoBehaviour
{
    public float visionRange = 10f;
    public float visionAngle = 60f;
    
    public LayerMask playerLayer;  
    public LayerMask obstacleLayer;

    private Transform player;

    private NavMeshAgent agent;
    private EnemieAction action;

    private bool canSeePlayer = false;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        action = GetComponent<EnemieAction>();
    }
    void Update()
    {
        CheckPlayerInVision();
        Debug.Log(canSeePlayer);
        if (canSeePlayer)
        {

        }
        else
        {

        }
    }

    void CheckPlayerInVision()
    {
        if (player == null) return;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (distanceToPlayer <= visionRange && angleToPlayer <= visionAngle / 2)
        {
            // Lanzamos un Raycast para verificar que no haya obstáculos entre el enemigo y el jugador
            if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer))
            {
                canSeePlayer = true;
                return;
            }
        }
        canSeePlayer = false;
    }

    void OnDrawGizmos()
    {
        // Dibujar el campo de visión en la escena
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector3 leftBoundary = Quaternion.Euler(0, -visionAngle / 2, 0) * transform.forward * visionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, visionAngle / 2, 0) * transform.forward * visionRange;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
