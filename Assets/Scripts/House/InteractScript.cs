using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class InteractScript : MonoBehaviour
{
    public Interactables[] interactables;
    int currentInteractable = 0;
    public bool interacted;
    public bool allTasksCompleted;
    public float timeSinceInteracted = 0;

    public GameObject watchNotifications;

    // Update is called once per frame
    void Update()
    {
        if (interactables[currentInteractable].interactable.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact"))
        {
            interacted = true;
        }

        if (interacted == true)
        {
            timeSinceInteracted += Time.fixedDeltaTime;

            if (interactables[currentInteractable].animator != null)
            {
                interactables[currentInteractable].animator.SetBool("Activate", true);
                if (interactables[currentInteractable].animator.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
                {
                    TaskCompleted();
                }
            }
            if (interactables[currentInteractable].portable == true)
            {
                interactables[currentInteractable].interactable.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                interactables[currentInteractable].interactable.transform.localPosition = Vector3.Slerp(interactables[currentInteractable].interactable.transform.localPosition, interactables[currentInteractable].offset, interactables[currentInteractable].pickupTime);
            }
            if (interactables[currentInteractable].freezeState == true)
            {

                if (interactables[currentInteractable].freezeDuration < timeSinceInteracted)
                {
                    TaskCompleted();
                } else
                {
                    GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Slerp(GameObject.FindGameObjectWithTag("Player").transform.position, interactables[currentInteractable].freezePosition, interactables[currentInteractable].freezeTransition);
                }
            }
            if (interactables[currentInteractable].material == true)
            {
                interactables[currentInteractable].interactable.GetComponent<MeshRenderer>().material = interactables[currentInteractable].material;
                if (interactables[currentInteractable].freezeState == false)
                {
                    TaskCompleted();
                }
            }
        }
    }

    void TaskCompleted()
    {
        ResetVariables();

        if (currentInteractable + 1 < interactables.Length && currentInteractable + 1 != interactables.Length)
        {
            currentInteractable += 1;
            watchNotifications.GetComponent<Notifications>().notiNum += 1;
        }
        else
        {
            if (allTasksCompleted == false)
            {
                watchNotifications.GetComponent<Notifications>().notiNum += 1;
                Debug.Log("All tasks completed");
                allTasksCompleted = true;
            }
        }
    }

    void ResetVariables()
    {
        interacted = false;
        timeSinceInteracted = 0;
    }
}