using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool playerAlive;
    public bool sleeping;
    public bool interacting;
    public bool watchingTV;
    public bool playerTouchedMonster;

    public GameObject player;
    public GameObject cam;
    public GameObject GUI;

    public GameObject clock;

    public GameObject deathScreen;

    // Update is called once per frame
    void Update()
    {
        if (!playerAlive)
        {
            Death();
        }

        if (interacting)
        {
            Debug.Log("interacting");
            player.GetComponent<PlayerController>().enabled = false;
            cam.GetComponent<MouseLook>().enabled = false;
        } else
        {
            player.GetComponent<PlayerController>().enabled = true;
            cam.GetComponent<MouseLook>().enabled = true;
        }

        if (clock.GetComponent<Clock>().currentHour == 18f)
        {
            Win();
        }
    }

    void Death()
    {
        Cursor.lockState = CursorLockMode.None;

        GUI.SetActive(false);

        deathScreen.SetActive(true);

        cam.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
    }

    void Win()
    {

    }
}