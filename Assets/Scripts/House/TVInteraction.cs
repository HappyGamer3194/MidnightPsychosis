using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVInteraction : MonoBehaviour
{
    public GameObject trigger;

    public GameObject SanityMeter;
    public float Sanity;
    public bool watching;
    public float sanityRefillRate;

    public GameManager gameManager;
    public GameObject postProcessing;

    public GameObject player;
    public GameObject cam;

    // Update is called once per frame
    void Update()
    {
        //If in trigger and interact button is pressed, sleeping = true
        if (trigger.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact"))
        {
            watching = !watching;
            Debug.Log("Watching TV : " + watching);
        }

        //if sleeping is true, sleep.
        if (watching == true)
        {
            gameManager.GetComponent<GameManager>().watchingTV = true;

            WatchTV();

        }
        else if (watching == false)
        {
            gameManager.GetComponent<GameManager>().watchingTV = false;

            player.GetComponent<PlayerController>().enabled = true;
        }
    }

    void WatchTV()
    {
        SanityMeter.GetComponent<Image>().fillAmount += sanityRefillRate;

        player.GetComponent<PlayerController>().enabled = false;
        gameManager.interacting = true;
    }
}
