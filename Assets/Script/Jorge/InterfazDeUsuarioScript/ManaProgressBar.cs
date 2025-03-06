using UnityEngine;
using UnityEngine.UI;

public class ManaProgressBar : MonoBehaviour
{
    private ManaUsage spell;
    public Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spell = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<ManaUsage>();    

    }

    // Update is called once per frame
    void Update()
    {
        
        image.fillAmount = (float)spell.mana / spell.maxMana;
    }
}
