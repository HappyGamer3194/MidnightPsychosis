using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DoorController : MonoBehaviour
{
    public GameObject trigger;
    public Animator doorAnimation;

    private void Update()
    {
        if (trigger.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact"))
        {
            doorAnimation.SetBool("openClose", true);
        }
    }
}
