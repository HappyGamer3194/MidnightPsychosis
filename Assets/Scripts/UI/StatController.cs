using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public float rate;
    public bool isDecreasing;
    public static GameObject pauseMenuUI;

    //Set "stat" to the child (Fill) under the radial meter
    public GameObject stat;

    public float currentAmount;

    // Start is called before the first frame update
    void Start()
    {
        currentAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isGamePaused)
        {
            stat.GetComponent<Image>().fillAmount = currentAmount;

            if (isDecreasing)
            {
                currentAmount -= rate;
            }

            if (currentAmount > 1)
            {
                currentAmount = 1;
            }

            if (currentAmount < 0)
            {
                currentAmount = 0;
            }
        }
    }

    public void ResetValues()
    {
        currentAmount = 1;
    }
}
