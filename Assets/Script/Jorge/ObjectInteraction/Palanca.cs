using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Palanca : MonoBehaviour
{
    private float openPlayer = 0;
    public int openTime = 1;

    public Image progressBar;
    public Image notProgressBar;

    public TextMeshPro text;
    

    private int bucles = 0;
    private bool isBucle = false;

    public GameObject[] enemiesInactives;
    public GameObject[] killEnemies;

    public GameObject palanca;

    public AudioClip sound;
    private AudioGestions audio;

    public FinalDoorEnd finalDoorEnd;
    private void Start()
    {
        audio = GetComponent<AudioGestions>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                onOpenDoor();
            
        }
    }


    private void Update()
    {
        if (!isBucle || bucles > 200)
        {
            return;
        }

        text.text += " GET OUT";
        bucles++;

    }


    public void onOpenDoor()
    {
        if (Input.GetKey(KeyCode.E) && !isBucle)
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
        Destroy(progressBar);
        Destroy(notProgressBar);
        finalDoorEnd.isEnded = true;
        text.text = "";
        isBucle = true;
        palanca.transform.Rotate(90, 0, 0);
        for (int i = 0; i<3; i++)
        {
            audio.playAudio(sound);
        }
        
        for(int i = 0; i < enemiesInactives.Length; i++)
        {
            
            enemiesInactives[i].SetActive(true);
        }
        for (int i = 0; i < killEnemies.Length; i++)
        {
            if (killEnemies[i] != null)
            {
                killEnemies[i].transform.GetComponentInChildren<EnemiesDie>().dying();
            }
          
        }
    }
}
