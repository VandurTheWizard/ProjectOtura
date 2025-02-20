using UnityEngine;
using TMPro;

public class InteractiveUIManager : MonoBehaviour
{
    [Header("Interactive UI")]
    [SerializeField]private TextMeshProUGUI interactiveText;

    void Start()
    {
        if(interactiveText == null)
        {
            interactiveText = GetComponent<TextMeshProUGUI>();
        }
    }

    public void ShowData(string text)
    {
        interactiveText.text = text;
    }

    public void HideData()
    {
        interactiveText.text = "";
    }

}
