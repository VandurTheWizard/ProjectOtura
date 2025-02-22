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
            other.gameObject.GetComponent<EnemieAction>().onStay();
            FloorUsages.resetPlaneWithDestroyGameObject(gameObject);
        }
    }
}
