using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject[] interactables;
    public int currentInteractable = 0;

    public string input;

    // Update is called once per frame
    void Update()
    {
        if (currentInteractable != interactables.Length)
        {
            if (interactables[currentInteractable].GetComponent<Trigger>().entered == true)
            {
                currentInteractable += 1;
            }
        }
    }
}