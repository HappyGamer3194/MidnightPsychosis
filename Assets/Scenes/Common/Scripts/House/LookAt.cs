using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject trigger;
    public GameObject letterUI;
    public GameObject door;

    public string input;

    bool lookingAt;
    bool lookedAt;

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetComponent<Trigger>().entered == true && Input.GetButtonDown(input))
        {
            lookingAt = !lookingAt;
        }

        if (lookingAt == false)
        {
            GetComponent<MeshRenderer>().enabled = true;
            letterUI.SetActive(false);
        }

        if (lookingAt && lookedAt == false)
        {
            GetComponent<MeshRenderer>().enabled = false;
            letterUI.SetActive(true);

            if (Input.GetButtonDown(input))
            {
                lookedAt = true;
            }
        }

        if (lookedAt)
        {
            door.GetComponent<DoorController>().isDoorEnabled = true;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
