using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public bool isEnable = false;
    public int stayTime = 5;
    private void OnTriggerStay(Collider other)
    {
        if (!isEnable)
            return;

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<CirclePatrollMovement>() != null)
            {
                FloorUsages.resetPlaneWithDestroyGameObject(gameObject);
            }
            else
            {
                other.gameObject.GetComponent<Attack>().resetAttack();
                other.gameObject.GetComponent<EnemieAction>().onStay(stayTime);
                FloorUsages.resetPlaneWithDestroyGameObject(gameObject);
            }

        }
    }
}
