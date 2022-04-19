using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepInteract : MonoBehaviour
{
    public GameObject trigger;

    public GameObject fatigueMeter;
    public float fatigue;
    public bool sleeping;
    public float fatigueRefillRate;

    public GameManager gameManager;
    public GameObject postProcessing;

    public GameObject player;
    public GameObject cam;

    // Update is called once per frame
    void Update()
    {
        //If in trigger and interact button is pressed, sleeping = true
        if(trigger.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact"))
        {
            sleeping = !sleeping;
            Debug.Log("sleeping : " + sleeping);
        }
 
        fatigue = fatigueMeter.GetComponent<StatController>().currentAmount;

        //if sleeping is true, sleep.
        if (sleeping == true)
        {
            gameManager.GetComponent<GameManager>().sleeping = true;

            Sleep();

        } else if (sleeping == false)
        {
            gameManager.GetComponent<GameManager>().sleeping = false;

            Wake();
        }
    }

    void Sleep()
    {
        fatigueMeter.GetComponent<StatController>().currentAmount += fatigueRefillRate;

        //Add eye close animation here

        gameManager.interacting = true;
    }

    void Wake()
    {
        //Add eye open animation here

        gameManager.interacting = false;
    }
}
