using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkInteract : MonoBehaviour
{
    public bool drinking;

    public GameManager gameManager;
    public GameObject trigger;
    public GameObject thirstMeter;
    public GameObject cam;

    #region GUI
    public GameObject waitSlider;
    public Slider slider;
    public float sliderRate;
    #endregion

    private void Start()
    {
        drinking = false;
    }

    // Update is called once per frame
    void Update()
    {

        //If in trigger and interact button is pressed, sleeping = true
        if (trigger.GetComponent<Trigger>().entered == true && Input.GetButtonDown("Interact") && !drinking)
        {
            slider.value = 0;
            gameManager.interacting = true;
            drinking = true;

            Debug.Log("drinking : " + drinking);
        }

        if (drinking == true)
        {
            Drink();
        }
    }

    void Drink()
    {
        drinking = true;
        waitSlider.SetActive(true);
        slider.value += sliderRate;

        if(slider.value == 1)
        {
            waitSlider.SetActive(false);
            drinking = false;
            gameManager.interacting = false;

            thirstMeter.GetComponent<StatController>().currentAmount = 1f;
        }
    }
}
