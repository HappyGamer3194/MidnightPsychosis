using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnInteract : MonoBehaviour
{
    public GameObject trigger;
    public GameObject objectToAppear;
    public GameObject door;
    public GameObject otherDoor;

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetComponent<Trigger>().entered && Input.GetButtonDown("Interact"))
        {
            objectToAppear.SetActive(true);
            door.SetActive(true);
            otherDoor.SetActive(false);
        }
    }
}
