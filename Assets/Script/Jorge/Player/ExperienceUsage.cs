using UnityEngine;

public class ExperienceUsage : MonoBehaviour
{
    public int lv = 0;
    public int exp = 0;
    public int restExp = 0;

    private ManaSpell[] manaSpell;

    private const int expLevel1 = 1050;
    private const int expLevel2 = 1650;
    private const int expLevel3 = 2300;
    private int[] expLevel = { expLevel1, expLevel2, expLevel3};

    public const int MAXLEVEL = 4;

    private void Start()
    {
        manaSpell = GetComponents<ManaSpell>();
    }

    // Update is called once per frame
    void Update()
    {
        if(exp >= restExp && lv != MAXLEVEL)
        {
            if (lv != MAXLEVEL - 1)
            {
                exp -= restExp;
                restExp = expLevel[lv];
            }
            lv++;

            for (int i = 0; i < manaSpell.Length; i++)
            {
               if(manaSpell[i].getSpellValue() == lv)
                {
                    manaSpell[i].setEnable(true);
                    break;
                }
            }
        }

    }
}
