using System.Collections;
using UnityEngine;

public class AttackWIthWater : MonoBehaviour
{
    public Vector3 positionOnCreateWater;
    public GameObject Water;
    private bool isCreateWater = true;
    private int nextWater = 5;

    public void onAttack()
    {
        if(!isCreateWater) return;
        Instantiate(Water, positionOnCreateWater, Quaternion.identity);
        isCreateWater = false;
        StartCoroutine(couldDown());
    }


    private IEnumerator couldDown()
    {
        yield return new WaitForSeconds(nextWater);
        isCreateWater = true;

    }
}
