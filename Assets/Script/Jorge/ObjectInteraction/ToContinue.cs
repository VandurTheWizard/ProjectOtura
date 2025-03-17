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
    public Image imagen;
    public TextMeshProUGUI text;

    public AudioClip music;
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
        imagen.fillAmount = openPlayer / openTime;
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
        interfaceOpen.onOpen();

    }
}
