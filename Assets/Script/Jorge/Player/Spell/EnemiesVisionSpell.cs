using System.Collections;
using UnityEngine;

public class EnemiesVisionSpell : MonoBehaviour, ManaSpell
{
    public int manaValue;
    public int spellValue;
    public bool enable = true;
    public float visibleEnemiesTime = 0.1f;

    public Camera mainCamera;

    public LayerMask everyThing;
    public LayerMask enemies;


    public AudioClip music;
    private AudioGestions gestions;
   

    private ManaUsage mana;



    private void Start()
    {
        gestions = GetComponentInChildren<AudioGestions>();
        mana = GetComponent<ManaUsage>();
    }
    public int getManaSpell()
    {
        return manaValue;
    }

    public int getSpellValue()
    {
        return spellValue;
    }

    public void SpellAttack()
    {
        enable = false;
        StartCoroutine(CreateRayCast());
    }

    private IEnumerator CreateRayCast()
    {

        mana.loseMana(manaValue);
        ChangeLayerMask(enemies);
        gestions.playAudio(music);
        yield return new WaitForSeconds(visibleEnemiesTime);
        ChangeLayerMask(everyThing);
        mana.isCasting = false;
        enable = true;
        yield break;


    }


    private void ChangeLayerMask(LayerMask layer)
    {
        mainCamera.cullingMask = layer;
    }

    bool ManaSpell.isEnable()
    {
        return enable;
    }

    public void setEnable(bool enable)
    {
        this.enable = enable;
    }
}
