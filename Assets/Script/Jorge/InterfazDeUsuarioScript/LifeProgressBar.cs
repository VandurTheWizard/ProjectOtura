using UnityEngine;
using UnityEngine.UI;

public class LifeProgressBar : MonoBehaviour
{
    private LifeUsage life;
    private ExperienceUsage experience;

    public Image image;

    private const float MAXSCALEY = 3.60f;
    private const float MAXPOSITIONY = 169;
    private const int MINSCALE = 1;
    private const int MINPOSITION = 0;
    private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        life = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<LifeUsage>();
        experience = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<ExperienceUsage>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localPosition = new Vector3(MINPOSITION, MAXPOSITIONY / ExperienceUsage.MAXLEVEL * experience.lv - MAXPOSITIONY, MINPOSITION);
        rectTransform.localScale = new Vector3(MINSCALE, MAXSCALEY / ExperienceUsage.MAXLEVEL * experience.lv, MINSCALE);


        image.fillAmount = (float)life.life / life.maxLife;
    }
}
