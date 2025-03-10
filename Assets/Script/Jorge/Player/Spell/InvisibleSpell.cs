using System.Collections;
using UnityEngine;

public class InvisibleSpell : MonoBehaviour, ManaSpell
{
    public int manaValue = 50;
    public int spellValue = 3;
    public bool enable = true;
    public bool isVisible = true;
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
        mana.loseMana(manaValue);
        isVisible = false;
        yield return new WaitForSeconds(invisibleTimePlayer);
        isVisible = true;
        mana.isCasting = false;
        enable = true;
        yield break;
    }

    public bool isEnable()
    {
        return enable;
    }

    public void setEnable(bool enable)
    {
        this.enable = enable;
    }
}