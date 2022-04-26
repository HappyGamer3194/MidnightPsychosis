using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject trigger;
    public GameObject letterUI;

    public string input;

    bool lookingAt;
    bool lookedAt = false;

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
            lookedAt = true;
        }

        if (lookingAt == false)
        {
            letterUI.SetActive(false);

            if (lookedAt == true)
            {
                GetComponent<MeshRenderer>().enabled = true;
                Destroy(gameObject);
            }
        }

        if (lookingAt)
        {
            GetComponent<MeshRenderer>().enabled = false;
            letterUI.SetActive(true);
        }
    }
}
