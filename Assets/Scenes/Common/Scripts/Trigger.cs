using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool entered;
    public bool exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entered = true;
            exited = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entered = false;
            exited = true;
        }
    }
}
