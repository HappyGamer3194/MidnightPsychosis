using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public Trigger trigger;
    public GameObject objectToAppear;

    // Update is called once per frame
    void Update()
    {
        if (trigger.entered)
        {
            objectToAppear.SetActive(true);
        }
    }
}
