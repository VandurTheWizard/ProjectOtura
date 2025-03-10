using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public int damage = 15;

    private void Update()
    {
        movementOfWater();
    }


    private void movementOfWater()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<LifeUsage>().loseLife(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Default"))
        {
            Destroy(gameObject);
        }
    }
}
