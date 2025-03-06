using UnityEngine;
using UnityEngine.UI;

public class LifeProgressBar : MonoBehaviour
{
    private LifeUsage life;

    public Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<LifeUsage>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = (float)life.life / life.maxLife;
    }
}
