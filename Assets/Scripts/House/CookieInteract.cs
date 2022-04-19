using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieInteract : MonoBehaviour
{
    public bool eating;

    public GameManager gameManager;
    public GameObject trigger;
    public GameObject eatMeter;
    public GameObject cam;

    #region GUI
    public GameObject waitSlider;
    public Slider slider;
    public float sliderRate;
    #endregion

    private void Start()
    {
        eating = false;
    }

    // Update is called once per frame
    void Update()
    {

        //If in trigger and interact button is pressed, sleeping = true
        if (trigger.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact") && !eating)
        {
            slider.value = 0;
            gameManager.interacting = true;
            eating = true;

            Debug.Log("eating : " + eating);
        }

        if (eating == true)
        {
            Eat();
        }
    }

    void Eat()
    {
        eating = true;
        waitSlider.SetActive(true);
        slider.value += sliderRate;

        if (slider.value == 1)
        {
            waitSlider.SetActive(false);
            eating = false;
            gameManager.interacting = false;

            eatMeter.GetComponent<StatController>().currentAmount = 1f;
        }
    }
}
