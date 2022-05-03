using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject[] interactables;
    public int currentInteractable = 0;

    public GameObject watchNotifications;

    // Update is called once per frame
    void Update()
    {
        if (currentInteractable != interactables.Length)
        {
            if (interactables[currentInteractable].GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact"))
            {
                watchNotifications.GetComponent<Notifications>().notiNum += 1;

                currentInteractable += 1;
            }
        }
    }
}