using System.Collections;
using UnityEngine;

public class FireSpell : MonoBehaviour, ManaSpell
{
    public GameObject fire;
    public int manaValue;
    public int spellValue;
    public bool isEnable = true;
    public int laserDistance = 10;

    private ManaUsage mana;
    private Camera mainCamera;
    private float waitTime = 0.1f;


    private void Start()
    {
        mana = GetComponent<ManaUsage>();
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
    }

    private IEnumerator CreateRayCast()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);


            Vector3 mousePosition = Input.mousePosition;

            Ray ray = mainCamera.ScreenPointToRay(mousePosition);


           
            if (Physics.Raycast(ray, out RaycastHit hit, laserDistance))
            {

                

            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                isEnable = true;
                mana.mana -= manaValue;
                mana.isCasting = false;
                yield break;
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                isEnable = true;
                mana.isCasting = false;
                yield break;
            }
        }

    }
}

