using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalDoorEnd : MonoBehaviour
{
    private float openPlayer = 0;
    public int openTime = 1;

    public Image progressBar;

    public GameObject canvas;
    public bool isEnded = false;

    public string endScene;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onOpenDoor();

        }
    }

    public void Update()
    {
        if (!isEnded)
            return;
        canvas.SetActive(true);

    }


    public void onOpenDoor()
    {
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

    private void onOpen()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(endScene);
    }
}