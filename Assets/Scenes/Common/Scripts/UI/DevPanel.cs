using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPanel : MonoBehaviour
{
    [Header("Activate Developer Panel")]
    public KeyCode key1;
    public KeyCode key2;
    public KeyCode key3;

    public GameObject devPanel;

    [Header("Skybox Materials")]
    public Material daySky;
    public Material nightSky;

    public void Start()
    {
        devPanel.SetActive(false);
    }

    public void Update()
    {
        //DISABLED THE DEV PANEL BECAUSE IT ISN'T REQUIRED.
        //StartCoroutine(TogglePanel());
    }

    public IEnumerator TogglePanel()
    {
        if (Input.GetKey(key1) &&
            Input.GetKey(key2) &&
            Input.GetKey(key3))
        {
            devPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        yield return new WaitForSeconds(1);
    }

    public void ChangeSkybox(string dayOrNight)
    {
        if(dayOrNight == "day")
        {
            RenderSettings.skybox = daySky;
        }
        else if(dayOrNight == "night")
        {
            RenderSettings.skybox = nightSky;
        }
    }

    public void CloseDevPanel()
    {
        devPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
