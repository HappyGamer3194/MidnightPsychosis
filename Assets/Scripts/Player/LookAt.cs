using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject trigger;
    public GameObject letterUI;

    public string input;

    bool lookingAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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

        if (lookingAt)
        {
            GetComponent<MeshRenderer>().enabled = false;
            letterUI.SetActive(true);
        }
    }
}
