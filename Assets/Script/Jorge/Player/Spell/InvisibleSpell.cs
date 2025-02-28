using System.Collections;
using UnityEngine;

public class InvisibleSpell : MonoBehaviour, ManaSpell
{
    public int manaValue = 50;
    public int spellValue = 3;
    public bool enable = true;
    public bool isVisible = false;
    public float invisibleTimePlayer = 5f;

    private ManaUsage mana;



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
        StartCoroutine(CreateRayCast());
    }

    private IEnumerator CreateRayCast()
    {
        enable = false;
        mana.mana -= manaValue;
        isVisible = true;
        yield return new WaitForSeconds(invisibleTimePlayer);
        isVisible = false;
        mana.isCasting = false;
        enable = true;
        yield break;
    }

    public bool isEnable()
    {
        return enable;
    }
}