using System.Collections;
using UnityEngine;

public class EnemiesVisionSpell : MonoBehaviour, ManaSpell
{
    public int manaValue;
    public int spellValue;
    public bool enable = true;
    public int maxTime = 5;

    public Camera mainCamera;

    public LayerMask everyThing;
    public LayerMask enemies;

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
  
        mana.mana -= manaValue;
        float time = 0;
        ChangeLayerMask(enemies);
        while (time < maxTime)
        {
            yield return waitTime;
            time += waitTime;
        }
        ChangeLayerMask(everyThing);
        mana.isCasting = false;
        enable = true;
        yield break;


    }


    private void ChangeLayerMask(LayerMask layer)
    {
        mainCamera.cullingMask = layer;
    }

    bool ManaSpell.isEnable()
    {
        return enable;
    }
}
