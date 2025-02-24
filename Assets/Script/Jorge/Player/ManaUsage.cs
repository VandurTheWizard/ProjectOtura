using UnityEngine;

public class ManaUsage : MonoBehaviour
{
    public ManaSpell [] spells;

    public int mana = 0;
    public int maxMana = 5;

    public bool isCasting = false;
    private const int TRAPSPELL = 1;
    private const int VISIONOFENEMIES = 2;
    private const int MANIPULATION =3;
    private const int TELETRANSPORT = 4;
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
            getSpell(TRAPSPELL);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            getSpell(VISIONOFENEMIES);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            getSpell(MANIPULATION);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            getSpell(TELETRANSPORT);
            return;
        }
    }


    public void getSpell(int spell)
    {
        for (int i = 0; i < spells.Length; i++)
        {
            if (spells[i].getSpellValue() == spell)
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
