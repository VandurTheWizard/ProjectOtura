using UnityEngine;
using UnityEngine.UI;

public class ExperienceProgressBar : MonoBehaviour
{
    private ExperienceUsage experience;

    public Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        experience = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<ExperienceUsage>();
    }

    // Update is called once per frame
    void Update()
    {

        image.fillAmount = (float)experience.exp / experience.restExp;
    }
}
