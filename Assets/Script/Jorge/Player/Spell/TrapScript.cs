using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public bool isEnable = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isEnable)
            return;

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<EnemiesCircleAction>() != null)
            {
                FloorUsages.resetPlaneWithDestroyGameObject(gameObject);
            }
            else
            {
                other.gameObject.GetComponent<EnemieAction>().onStay();
                FloorUsages.resetPlaneWithDestroyGameObject(gameObject);
            }

        }
    }
}
