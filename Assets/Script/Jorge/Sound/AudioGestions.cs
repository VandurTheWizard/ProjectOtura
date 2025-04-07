using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioGestions : MonoBehaviour
{

    public static float volumen = 50;

    public void playAudio(AudioClip audio)
    {
        AudioSource radio = gameObject.AddComponent<AudioSource>();
        radio.volume = volumen / 100;
        radio.clip = audio;
        radio.Play();
        StartCoroutine(stopAudio(radio));
    }

    private IEnumerator stopAudio(AudioSource audio)
    {
        while (audio.isPlaying) yield return null;

        Destroy(audio);
    } 


    public AudioSource deleteMyself(AudioClip audio)
    {
        AudioSource radio = gameObject.AddComponent<AudioSource>();
        radio.clip = audio;
        radio.Play();
        return radio;
    }

    public void playBucle(AudioClip audio)
    {
        AudioSource radio = gameObject.AddComponent<AudioSource>();
        radio.clip = audio;
        radio.Play();
        radio.loop = true;
        StartCoroutine(changeVolumen(radio));
    }

    public IEnumerator changeVolumen(AudioSource audio)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            audio.volume = volumen / 100;
        }
      
    }

}
