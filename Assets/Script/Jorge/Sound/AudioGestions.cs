using System.Collections;
using UnityEngine;

public class AudioGestions : MonoBehaviour
{
    


    public void playAudio(AudioClip audio)
    {
        AudioSource radio = gameObject.AddComponent<AudioSource>();
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
}
