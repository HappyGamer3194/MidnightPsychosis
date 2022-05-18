using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DoorController : MonoBehaviour
{
    public GameObject trigger;
    public Animator doorAnimation;
    public bool isDoorEnabled = true;

    private void Update()
    {
        if (trigger.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact") && isDoorEnabled)
        {
            if(doorAnimation.GetBool("openClose") == false)
            {
                doorAnimation.SetBool("openClose", true);
            }
            else if(doorAnimation.GetBool("openClose") == true)
            {
                doorAnimation.SetBool("openClose", false);
            }
        }
    }
}
