using UnityEngine;

public class ExperienceUsage : MonoBehaviour
{
    public int lv = 0;
    public int exp = 0;
    public int restExp = 0;

    private ManaSpell[] manaSpell;

    private const int EXPLEVEL1 = 1050;
    private const int EXPLEVEL2 = 1150;
    private const int EXPLEVEL3 = 1200;
    private int[] expLevel = { EXPLEVEL1, EXPLEVEL2, EXPLEVEL3};

    private const int LIFELEVEL1 = 100;
    private const int LIFELEVEL2 = 70;
    private const int LIFELEVEL3 = 70;
    private const int LIFELEVEL4 = 50;

    private int[] lifeLevel = { LIFELEVEL1 , LIFELEVEL2 , LIFELEVEL3 , LIFELEVEL4};

    private const int MANALEVEL1 = 100;
    private const int MANALEVEL2 = 50;
    private const int MANALEVEL3 = 75;
    private const int MANALEVEL4 = 75;

    private int[] manaLevel = { MANALEVEL1, MANALEVEL2, MANALEVEL3, MANALEVEL4};

    private LifeUsage life;
    private ManaUsage mana;

    public const int MAXLEVEL = 4;

    private void Start()
    {
        life = GetComponent<LifeUsage>();
        mana = GetComponent<ManaUsage>();
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
            life.maxLife += lifeLevel[lv];
            life.life += lifeLevel[lv];
            mana.maxMana += manaLevel[lv];
            mana.mana += manaLevel[lv];

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
