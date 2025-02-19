using UnityEngine;

public class ManaUsage : MonoBehaviour
{
    public ManaSpell [] spells;

    private const int FUEGO = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spells = GetComponents<ManaSpell>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            if (spells[i].getSpellValue() == FUEGO)
            {
                spells[0].SpellAttack();
            }
        }
        
    }
}
