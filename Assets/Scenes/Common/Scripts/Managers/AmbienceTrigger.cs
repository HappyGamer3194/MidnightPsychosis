using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceTrigger : MonoBehaviour
{
    private AmbientSoundManager asm;
    public int SoundNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            asm = other.gameObject.GetComponent<AmbientSoundManager>();
            asm.PlaySound(SoundNumber);
        }
    }
}
