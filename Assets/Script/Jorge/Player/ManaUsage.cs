using System.Collections;
using TMPro;
using UnityEngine;

public class ManaUsage : MonoBehaviour
{
    public ManaSpell [] spells;

    public int mana = 0;
    public int maxMana = 5;

    public TextMeshProUGUI information;

    public bool isCasting = false;

    private float waitTime = 0.1f;
    public const int TRAPSPELL = 1;
    public const int VISIONOFENEMIES = 2;
    public const int MANIPULATION =3;
    public const int TELETRANSPORT = 4;
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
                if (spells[i].getManaSpell() > mana || !spells[i].isEnable())
                {
                    if(spells[i].getManaSpell() > mana)
                    {
                        viewText("You not have enough mana");
                    }
                    else
                    {
                        viewText("The spell not is enable");
                    }
                    
                }
                else
                {
                    isCasting = true;
                    spells[i].SpellAttack();
                }

            }
        }
    }

    private void viewText(string text)
    {
        TextMeshProUGUI informationText = Instantiate(information, information.transform);
        informationText.text = text;
        StartCoroutine(moveText(informationText));
    }

    private IEnumerator moveText(TextMeshProUGUI text)
    {
        float time = 0;
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            time += waitTime;


            text.transform.position += new Vector3(0, 1, 0) * 100 * time;

            if(time > 2){
                Destroy(text.gameObject);
                yield break;
            }

        }
    }
}
