using UnityEngine;

public class EnemiesDie : MonoBehaviour
{

    public GameObject soul;

    private float deathTime = 0;

    public int dieTime = 1;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !transform.parent.GetComponent<EnemieAction>().isPlayerVisible())
            {
                deathTime += Time.deltaTime;
            }
            else
            {
                deathTime = 0;
            }

            if (deathTime >= dieTime)
            {
                Instantiate(soul, transform.parent.position, Quaternion.identity);
                Destroy(transform.parent.gameObject);
            }
        }
    }

}
