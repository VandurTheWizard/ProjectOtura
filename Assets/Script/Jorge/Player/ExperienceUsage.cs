using UnityEngine;

public class ExperienceUsage : MonoBehaviour
{
    public int lv = 0;
    public int exp = 0;
    public int restExp = 0;

    private const int expLevel1 = 1050;
    private const int expLevel2 = 1650;
    private const int expLevel3 = 2300;
    private const int expLevel4 = 3000;
    private int[] expLevel = { expLevel1, expLevel2, expLevel3, expLevel4 };

    public const int MAXLEVEL = 4;

    // Update is called once per frame
    void Update()
    {
        if(exp >= restExp)
        {
            exp -= restExp;
            restExp = expLevel[lv];
            lv++;
        }
    }
}
