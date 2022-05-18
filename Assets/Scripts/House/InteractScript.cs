using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class InteractScript : MonoBehaviour
{
    public Interactables[] interactables;
    public int currentInteractable = 0;
    bool interacted;

    public GameObject watchNotifications;

    // Update is called once per frame
    void Update()
    {
        if (interactables[currentInteractable].interactable.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact"))
        {
            interacted = true;

            if (interactables[currentInteractable].animator != null)
            {
                interactables[currentInteractable].animator.SetBool("Activate", true);
            }

            if (interactables[currentInteractable].portable == false)
            {
                if (currentInteractable + 1 < interactables.Length && interactables[currentInteractable].portable == false)
                {
                    watchNotifications.GetComponent<Notifications>().notiNum += 1;
                    currentInteractable += 1;
                    Debug.Log("Task Completed");
                }
                else if (interactables[currentInteractable].portable == false)
                {
                    watchNotifications.GetComponent<Notifications>().notiNum += 1;
                    Debug.Log("All tasks completed");
                }
            }
        }
        if (interactables[currentInteractable].portable == true && interacted == true)
        {
            interactables[currentInteractable].interactable.transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position + interactables[currentInteractable].offset;
        }
    }
}