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

    public AudioClip music;

    private float waitTime = 2f;
    public const int TRAPSPELL = 1;
    public const int VISIONOFENEMIES = 2;
    public const int MANIPULATION =3;
    public const int TELETRANSPORT = 4;

    private Coroutine coroutine;

    private AudioGestions gestions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gestions = GetComponentInChildren<AudioGestions>();
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
                if ( isLoseMana(spells[i].getManaSpell()) || !spells[i].isEnable())
                {
                    if(!spells[i].isEnable())
                    {
                        viewText("The spell not is enable");
                        
                    }
                    else
                    {
                        viewText("You not have enough mana");
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
        if(coroutine != null)
            StopCoroutine(coroutine);
        information.text = text;
        coroutine = StartCoroutine(moveText(information));
    }

    private IEnumerator moveText(TextMeshProUGUI text)
    {
        gestions.playAudio(music);
        yield return new WaitForSeconds(waitTime);

        information.text = "";
    }

    public void loseMana(int mana)
    {
        if(this.mana - mana < 0)
        {
            this.mana = 0;
        }
        else
        {
            this.mana -= mana;
        }
       
    }

    public bool isLoseMana(int mana)
    {
        return this.mana - mana < 0;
    }

    public void recieveMana(int mana)
    {
        if(this.mana + mana >= maxMana)
        {
            this.mana = maxMana;
        }
        else
        {
            this.mana += mana;
        }
    }
}
