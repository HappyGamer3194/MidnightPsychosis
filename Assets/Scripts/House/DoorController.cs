using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DoorController : MonoBehaviour
{
    public GameObject trigger;
    public Animator doorAnimation;
    public bool isDoorEnabled = true;

    private Collider doorCollider;

    private void Start()
    {
        doorCollider = gameObject.GetComponent<Collider>();
    }

    private void Update()
    {
        if (trigger.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact") && isDoorEnabled)
        {
            StartCoroutine(DoorAnimation());
        }
    }

    private IEnumerator DoorAnimation()
    {
        doorCollider.enabled = false;

        yield return new WaitForSeconds(0.1f);

        if (doorAnimation.GetBool("openClose") == false)
        {
            doorAnimation.SetBool("openClose", true);
        }
        else if (doorAnimation.GetBool("openClose") == true)
        {
            doorAnimation.SetBool("openClose", false);
        }

        yield return new WaitForSeconds(1f);

        doorCollider.enabled = true;
    }
}
