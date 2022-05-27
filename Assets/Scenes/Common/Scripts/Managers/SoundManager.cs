using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource ambient;

    void Start()
    {
        StartCoroutine(StartFade(ambient));
    }

    // linearized volume slider using logarithms ew
    public void SetVolume (float sliderValue)
    {   
        mixer.SetFloat("masterVol", Mathf.Log10(sliderValue) * 20);
    }

    // coroutine for fading in music
    IEnumerator StartFade(AudioSource audioSource)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 1, currentTime / 10);
            yield return null;
        }
        yield break;
    }
}
