using System.Collections;
using UnityEngine;

public class HandlingSpell : MonoBehaviour, ManaSpell
{
    public int manaValue;
    public int spellValue;
    public bool enable = true;
    public int laserDistance = 9999;
    public LayerMask enemiesLayer;

    public Camera mainCamera;

    private GameObject enemies;
    private ManaUsage mana;
    private float waitTime = 0.1f;


    private void Start()
    {
        mana = GetComponent<ManaUsage>();
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
        enable = false;
        StartCoroutine(CreateRayCast());
    }

    private IEnumerator CreateRayCast()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);


            Vector3 mousePosition = Input.mousePosition;

            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, laserDistance, enemiesLayer))
            {

                enemies = hit.collider.gameObject;

            }


            if (Input.GetKey(KeyCode.Mouse0) && enemies != null)
            {
                enemies.GetComponent<EnemiesStatus>().onHandling();
                enemies = null;
                enable = true;
                mana.mana -= manaValue;
                mana.isCasting = false;
                yield break;
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                enemies = null;
                enable = true;
                mana.isCasting = false;
                yield break;
            }
        }


    }

    public bool isEnable()
    {
        return enable;
    }
}