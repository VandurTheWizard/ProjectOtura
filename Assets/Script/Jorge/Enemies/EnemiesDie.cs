using UnityEngine;
using UnityEngine.UI;

public class EnemiesDie : MonoBehaviour
{

    public GameObject soul;

    private float deathTime = 0;

    public int dieTime = 1;

    public GameObject canvas;
    public Image imagen;

    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
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
            imagen.fillAmount = deathTime / dieTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
