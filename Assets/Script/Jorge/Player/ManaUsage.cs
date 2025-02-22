using UnityEngine;

public class ManaUsage : MonoBehaviour
{
    public ManaSpell [] spells;

    public int mana = 0;
    public int maxMana = 5;

    private const int TRAPSPELL = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spells = GetComponents<ManaSpell>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < spells.Length; i++)
            {
                if(spells[i].getSpellValue() == TRAPSPELL)
                {
                    spells[i].SpellAttack();
                }
            }
        }
    }
}
