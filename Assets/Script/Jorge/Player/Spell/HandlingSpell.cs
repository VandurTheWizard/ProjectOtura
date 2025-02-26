using System.Collections;
using UnityEngine;

public class HandlingSpell : MonoBehaviour, ManaSpell
{
    public int manaValue = 50;
    public int spellValue = 3;
    public bool enable = true;
    public int laserDistance = 10;
    public LayerMask enemiesLayer;

    public Camera mainCamera;

    private GameObject enemies;
    private ManaUsage mana;
    private float waitTime = 0.01f;


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

            Debug.DrawRay(ray.origin, ray.direction * laserDistance, Color.red, 0.5f);

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