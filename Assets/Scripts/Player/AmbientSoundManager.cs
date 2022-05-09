using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int number)
    {
        audioSource.PlayOneShot(sounds[number]);
    }
}
