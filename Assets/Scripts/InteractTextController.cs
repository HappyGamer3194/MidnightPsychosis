using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractTextController : MonoBehaviour
{
    public GameObject interactText;

    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        interactText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interactText.SetActive(false);
    }
}
