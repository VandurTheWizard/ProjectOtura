using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public int damage = 15;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<LifeUsage>().loseLife(damage);
            Destroy(gameObject);
        }
    }
}
