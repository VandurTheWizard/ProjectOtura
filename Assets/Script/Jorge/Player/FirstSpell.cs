using UnityEngine;

public class FirstSpell : MonoBehaviour, ManaSpell
{
    public int manaValue;
    public int spellValue;
    public int getManaSpell()
    {
        return manaValue;
    }

    public int getSpellValue()
    {
        return spellValue;
    }

    public int SpellAttack()
    {
        Debug.Log(2);
        return 0;
    }

 
}
