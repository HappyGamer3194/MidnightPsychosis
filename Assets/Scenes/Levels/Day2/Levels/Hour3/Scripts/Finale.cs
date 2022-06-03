using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale : MonoBehaviour
{
    public GameObject mesh;
    public GameObject trigger;
    public AudioSource audioS;
    bool finished;

    // Update is called once per frame
    void Update()
    {
        if (finished == false && trigger.GetComponent<Trigger>().entered && Input.GetButtonDown("Interact"))
        {
            StartCoroutine(waitForSeconds(0.7f));
        }

        IEnumerator waitForSeconds (float seconds)
        { 
            finished = true;
            yield return new WaitForSeconds(seconds);
            audioS.Play();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(4);
        }
    }
}
