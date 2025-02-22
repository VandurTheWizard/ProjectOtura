using System.Collections;
using UnityEngine;

public class TrapInTheFloor : MonoBehaviour, ManaSpell
{
    public GameObject trap;
    public int manaValue;
    public int spellValue;
    public int laserDistance;
    public bool isEnable =true;


    private GameObject trapInFloor;
    private Camera mainCamera;
    private float waitTime = 0.1f;

    
    private void Start()
    {
        mainCamera = Camera.main;
    }
    public int getManaSpell()
    {
        return manaValue;
    }

    public int getSpellValue()
    {
        return spellValue;
    }

    public void SpellAttack()
    {
        if (!isEnable)
            return;
        isEnable = false;
        StartCoroutine(CreateRayCast());
    }

    private IEnumerator CreateRayCast()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            
            
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = mainCamera.ScreenPointToRay(mousePosition);


            Debug.DrawLine(ray.origin, ray.direction, Color.red, 3f);
            if (Physics.Raycast(ray, out RaycastHit hit, laserDistance))
            {

                CreateObject(hit);

            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                trapInFloor.GetComponent<TrapScript>().isEnable = true;
                trapInFloor.transform.SetParent(FloorUsages.plane.transform, true);
                FloorUsages.resetPlane();
                trapInFloor = null;
                isEnable = true;
                yield break;
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                Destroy(trapInFloor);
                trapInFloor = null;
                isEnable = true;
                yield break;
            }
        }
       
    }

    private void CreateObject(RaycastHit hit)
    {
        
        if (hit.collider.gameObject.CompareTag("Floor"))
        {
            if (trapInFloor != null)
                Destroy(trapInFloor);
            trapInFloor = Instantiate(trap, hit.point, Quaternion.identity);
        }
        
    }
}
