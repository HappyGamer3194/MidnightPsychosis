using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class InteractScript : MonoBehaviour
{
    public Interactables[] interactables;
    int currentInteractable = 0;
    bool interacted;
    public float pickupTime;

    public GameObject watchNotifications;

    // Update is called once per frame
    void Update()
    {
        if (interactables[currentInteractable].interactable.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact"))
        {
            interacted = true;
            if (interactables[currentInteractable].portable == false)
            {
                if (currentInteractable + 1 < interactables.Length)
                {
                    TaskCompleted();
                }
                else
                {
                    watchNotifications.GetComponent<Notifications>().notiNum += 1;
                    Debug.Log("All tasks completed");
                }
            }
        }
        if (interacted == true)
        {
            if (interactables[currentInteractable].changeMaterial == true)
            {
                interactables[currentInteractable].currentChangeTime += Time.fixedDeltaTime;
            }

            if (interactables[currentInteractable].animator != null)
            {
                interactables[currentInteractable].animator.SetBool("Activate", true);
            }
            if (interactables[currentInteractable].portable == true)
            {
                interactables[currentInteractable].interactable.transform.localPosition = Vector3.Slerp(interactables[currentInteractable].interactable.transform.localPosition, interactables[currentInteractable].offset, pickupTime);
                interactables[currentInteractable].interactable.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        //If the currentChangeTime is more that the changeTime

        if (interactables[currentInteractable].currentChangeTime > interactables[currentInteractable].changeTime)
        {
            //Change the material to the interacted material
            interactables[currentInteractable].interactable.GetComponent<MeshRenderer>().material = interactables[currentInteractable].material;
        }
        if (interactables[currentInteractable].animator != null)
        {
            if (interactables[currentInteractable].animator.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
            {
                TaskCompleted();
            }
        }
    }

    void TaskCompleted()
    {
        if (interactables[currentInteractable].portable)
        {
            interactables[currentInteractable].interactable.transform.localPosition = Vector3.Slerp(interactables[currentInteractable].interactable.transform.localPosition, interactables[currentInteractable].offset, pickupTime * Time.fixedDeltaTime);
            if (interactables[currentInteractable].endingLocation != null)
            {
                interactables[currentInteractable].interactable.transform.position = interactables[currentInteractable].endingLocation;
            } else
            {
                Debug.Log("endingPosition for " + interactables[currentInteractable].interactable.name + " is not set");
            }
            interactables[currentInteractable].interactable.transform.parent = null;
        }
        watchNotifications.GetComponent<Notifications>().notiNum += 1;
        currentInteractable += 1;
        Debug.Log("Task Completed");

        interacted = false;
    }
}