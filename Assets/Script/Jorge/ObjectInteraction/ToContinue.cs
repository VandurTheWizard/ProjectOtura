using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToContinue : MonoBehaviour
{
    private ObjectOpened interfaceOpen;
    private float openPlayer = 0;

    public int openTime = 1;
    public int levelOfOpen;

    public GameObject canvas;
    public Image progressBar;
    public Image notProgressBar;

    public TextMeshPro text;
    private void Start()
    {
        interfaceOpen = GetComponent<ObjectOpened>();
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<ExperienceUsage>().lv < levelOfOpen)
            {
                text.text = "You not have enough level";
            }
            else
            {
                if (!progressBar.gameObject.activeSelf)
                {
                    progressBar.gameObject.SetActive(true);
                    notProgressBar.gameObject.SetActive(true);
                }
                onOpenDoor();
            }
        }
    }



    public void onOpenDoor()
    {
        text.text = "Open the door with 'E'";
        if (Input.GetKey(KeyCode.E))
        {
            openPlayer += Time.deltaTime;
        }
        else
        {
            openPlayer = 0;
        }

        if (openPlayer >= openTime)
        {
            onOpen();
        }
        progressBar.fillAmount = openPlayer / openTime;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
        }
    }

    private void onOpen()
    {
        Destroy(canvas);
        interfaceOpen.onOpen();

    }
}
