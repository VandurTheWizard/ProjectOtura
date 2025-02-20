using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorEffect : MonoBehaviour
{
    [Header("Color Settings")]
    [Range(0f, 1f)]
    public float maxAlpha = 0.5f;
    public float fadeSpeed = 2f;
    public Color healthColor = Color.green;
    public Color damageColor = Color.red;
    public Color expColor = Color.yellow;

    private Image effectImage;
    private Color originalColor;
    private Color targetColor;
    private float currentAlpha = 0f;
    private bool isFading = false;

    void Awake()
    {
        effectImage = GetComponent<Image>();
        if (effectImage == null)
        {
            enabled = false;
            return;
        }
        originalColor = effectImage.color;
        currentAlpha = originalColor.a;
        SetAlpha(currentAlpha);
    }

    void Update()
    {
        if (isFading)
        {
            FadeAlpha();
        }
    }

    private void FadeAlpha()
    {
        if (effectImage.color.a < maxAlpha && targetColor.a > 0)
        {
            currentAlpha = Mathf.MoveTowards(effectImage.color.a, maxAlpha, fadeSpeed * Time.deltaTime);
        }
        else if (effectImage.color.a > originalColor.a && targetColor.a == 0)
        {
            currentAlpha = Mathf.MoveTowards(effectImage.color.a, originalColor.a, fadeSpeed * Time.deltaTime);
        }
        else if (Mathf.Approximately(effectImage.color.a, (targetColor.a > 0 ? maxAlpha : originalColor.a)))
        {
             if (targetColor.a == 0)
             {
                isFading = false;
             }
             else{
                StartFadeOut();
             }
        }
        SetAlpha(currentAlpha);
    }

    private void SetAlpha(float alphaValue)
    {
        Color currentColor = effectImage.color;
        currentColor.a = alphaValue;
        effectImage.color = currentColor;
    }

    public void ChangeColor(string type)
    {
        switch (type)
        {
            case "verde":
                targetColor = healthColor;
                break;
            case "rojo":
                targetColor = damageColor;
                break;
            case "amarillo":
                targetColor = expColor;
                break;
            default:
                return;
        }

        targetColor.a = 0;
        Color colorWithAlpha = targetColor;
        colorWithAlpha.a = effectImage.color.a;
        effectImage.color = colorWithAlpha;

        StartFadeIn();
    }

    private void StartFadeIn()
    {
        isFading = true;
        targetColor.a = 1;
    }

     private void StartFadeOut()
    {
        targetColor.a = 0;
    }
}