using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public Trigger trigger;

    // Update is called once per frame
    void Update()
    {
        if (trigger.entered)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
