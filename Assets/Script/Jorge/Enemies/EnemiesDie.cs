using UnityEngine;

public class EnemiesDie : MonoBehaviour
{

    public GameObject soul;

    private float deathTime = 0;

    private int DIETIMER = 2;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("DAS");
            if (Input.GetKey(KeyCode.E) && !transform.parent.GetComponent<EnemiesSee>().isPlayerVisible)
            {
                deathTime += Time.deltaTime;
            }
            else
            {
                deathTime = 0;
            }

            if (deathTime >= DIETIMER)
            {
                Instantiate(soul, transform.parent.position, Quaternion.identity);
                Destroy(transform.parent.gameObject);
            }
        }
    }

}
