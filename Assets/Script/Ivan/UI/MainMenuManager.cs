using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Referencias")]
    public AudioMixer audioMixer;
    public GameObject menu;
    public GameObject settings;
    public Slider sliderVolumenMusic;
    public Slider sliderVolumenSFX;

    void Start()
    {
        menu.SetActive(true);
        settings.SetActive(false);

        float volumenMusic;
        audioMixer.GetFloat("VolumenMusica", out volumenMusic);
        sliderVolumenMusic.value = volumenMusic;
        float volumenSFX;
        audioMixer.GetFloat("VolumenSFX", out volumenSFX);
        sliderVolumenSFX.value = volumenSFX;
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        menu.SetActive(true);
        settings.SetActive(false);
    }

    public void OpenCredits()
    {
        menu.SetActive(false);
        settings.SetActive(false);
    }

    public void CloseCredits()
    {
        menu.SetActive(true);
        settings.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

     public void SetVolumenMusic(float volumen)
    {
        audioMixer.SetFloat("VolumenMusica", volumen);
    }

    public void SetVolumenSFX(float volumen)
    {
        audioMixer.SetFloat("VolumenSFX", volumen);
    }
}
