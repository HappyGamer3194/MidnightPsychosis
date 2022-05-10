using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;

    public void PlaySound(int number)
    {
        audioSource.PlayOneShot(sounds[number]);
        Debug.Log("Played: " + number);
    }
}
