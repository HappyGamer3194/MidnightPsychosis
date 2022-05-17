using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class InteractScript : MonoBehaviour
{
    public Interactables[] interactables;
    public int currentInteractable = 0;

    public GameObject watchNotifications;

    // Update is called once per frame
    void Update()
    {
        if (currentInteractable != interactables.Length)
        {
            if (interactables[currentInteractable].interactable.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact"))
            {
                watchNotifications.GetComponent<Notifications>().notiNum += 1;

                if (interactables[currentInteractable].animator != null)
                {
                    interactables[currentInteractable].animator.SetBool("Activate", true);
                }
                currentInteractable += 1;
            }
        }
    }
}