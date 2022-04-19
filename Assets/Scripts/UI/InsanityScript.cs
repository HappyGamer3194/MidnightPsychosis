using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class InsanityScript : MonoBehaviour
{
    #region RayCasting

    public GameObject rayCastOrigin;
    public float rayCastDistance;
    public LayerMask monster;

    #endregion

    public GameObject playerController;
    public GameObject RadialBar;

    public GameObject thirst;
    public GameObject hunger;
    public GameObject fatigue;

    float thirstAmount;
    float hungerAmount;
    float fatigueAmount;

    public float rate;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isGamePaused)
        {
            thirstAmount = thirst.GetComponent<StatController>().currentAmount;
            hungerAmount = hunger.GetComponent<StatController>().currentAmount;
            fatigueAmount = fatigue.GetComponent<StatController>().currentAmount;

            if (thirstAmount == 0)
            {
                RadialBar.GetComponent<Image>().fillAmount -= rate;
            }
            if (hungerAmount == 0)
            {
                RadialBar.GetComponent<Image>().fillAmount -= rate;
            }
            if (fatigueAmount == 0)
            {
                RadialBar.GetComponent<Image>().fillAmount -= rate;
            }

            Ray ray = new Ray(rayCastOrigin.transform.position, rayCastOrigin.transform.forward * rayCastDistance);
            Debug.DrawRay(rayCastOrigin.transform.position, rayCastOrigin.transform.forward * rayCastDistance);
        }
    }
}
