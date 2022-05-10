using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;
    public float scale = 1;

    private int currentNumber;

    public void PlaySound(int number)
    {
        currentNumber = number;
        StartCoroutine(FadeSound());
    }

    IEnumerator FadeSound()
    {
        //Fade out
        audioSource.volume = 1f;
        yield return new WaitForSeconds(0.01f);

        for (float v = 1f; v > 0f; v -= scale * Time.deltaTime)
        {
            audioSource.volume = v;
        }

        yield return new WaitForSeconds(0.02f);

        //Change sound
        audioSource.PlayOneShot(sounds[currentNumber]);

        yield return new WaitForSeconds(0.02f);

        //Fade in
        audioSource.volume = 0f;
        yield return new WaitForSeconds(0.01f);

        for (float v = 0f; v < 1f; v += scale * Time.deltaTime)
        {
            audioSource.volume = v;
        }
    }
}
