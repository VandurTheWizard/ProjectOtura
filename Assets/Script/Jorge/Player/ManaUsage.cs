using UnityEngine;

public class ManaUsage : MonoBehaviour
{
    public ManaSpell [] spells;

    public int mana = 0;
    public int maxMana = 5;

    public bool isCasting = false;
    private const int TRAPSPELL = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spells = GetComponents<ManaSpell>();
    }

    // Update is called once per frame
    void Update() 
    {
        if (isCasting)
            return;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            getTrapSpell();
            return;
        }
    }


    public void getTrapSpell()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            if (spells[i].getSpellValue() == TRAPSPELL)
            {
                if (spells[i].getManaSpell() > mana)
                {

                }
                else
                {
                    isCasting = true;
                    spells[i].SpellAttack();
                }

            }
        }
    }
}
