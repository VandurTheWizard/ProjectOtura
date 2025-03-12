using System.Collections;
using UnityEngine;


public class AttackWIthWater : MonoBehaviour, Attack
{
    public GameObject Water;
    public LayerMask floorLayer;

    private bool isCreateWater = true;
    private int nextWater = 3;
    private Visible visible;


    private void Start()
    {
        visible = GetComponent<Visible>();
    }

    public void onAttack()
    {
        visible.onVisible();
        if (!isCreateWater) return;

        if(Physics.Raycast(transform.position + transform.forward, new Vector3(0,-2,0), out RaycastHit hit, floorLayer))
        {

            if (hit.collider.gameObject.CompareTag("Floor"))
            {
              Instantiate(Water, hit.point, Quaternion.identity);
            }
        }
        if (Physics.Raycast(transform.position + transform.forward + transform.right/3*2, new Vector3(0, -2, 0), out RaycastHit hit1, floorLayer))
        {
            if (hit1.collider.gameObject.CompareTag("Floor"))
            {
               Instantiate(Water, hit1.point, Quaternion.identity);
            }
        }
        if (Physics.Raycast(transform.position + transform.forward - transform.right / 3 * 2, new Vector3(0, -2, 0),out RaycastHit hit2, floorLayer))
        {
            if (hit2.collider.gameObject.CompareTag("Floor"))
            {
               Instantiate(Water, hit2.point, Quaternion.identity);
            }
        }

        isCreateWater = false;
        StartCoroutine(couldDown());
    }

    public void resetAttack()
    {

    }
    private IEnumerator couldDown()
    {
        yield return new WaitForSeconds(nextWater);
        isCreateWater = true;

    }
}
