using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public float rate;
    public bool isDecreasing;
    public static GameObject pauseMenuUI;

    PauseMenu pause = new PauseMenu();

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
        
    }

    public void ResetValues()
    {
        currentAmount = 1;
    }
}
