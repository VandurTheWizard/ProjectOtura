using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausaManager : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderVolumenMusic;
    [SerializeField] private Slider sliderVolumenSFX;   

    private bool isPaused = false;

    void Start()
    {
        float volumenMusic;
        audioMixer.GetFloat("VolumenMusica", out volumenMusic);
        sliderVolumenMusic.value = volumenMusic;
        float volumenSFX;
        audioMixer.GetFloat("VolumenSFX", out volumenSFX);
        sliderVolumenSFX.value = volumenSFX;   

        gameObject.SetActive(false);
    }

    public void OnMenuAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SetPause(!isPaused);
        }
    }

    public void SetPause(bool pause)
    {
        isPaused = pause;
        if (isPaused)
        {
            ActiveMenuPause();

            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void SetVolumenMusic(float volumen)
    {
        audioMixer.SetFloat("VolumenMusica", volumen);
    }

    public void SetVolumenSFX(float volumen)
    {
        audioMixer.SetFloat("VolumenSFX", volumen);
    }

    public void ActiveMenuPause()
    {
        menuPausa.SetActive(true);
        menuAjustes.SetActive(false);
    }

    public void ActiveMenuAjustes()
    {
        menuPausa.SetActive(false);
        menuAjustes.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
