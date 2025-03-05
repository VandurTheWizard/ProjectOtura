using UnityEngine;

public interface ManaSpell
{
    public int getManaSpell();
    public int getSpellValue();
    public void SpellAttack();
    public bool isEnable();

    public void setEnable(bool enable);

}
