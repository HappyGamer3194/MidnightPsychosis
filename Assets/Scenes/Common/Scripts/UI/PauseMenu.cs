using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadSettings ()
    {
        Debug.Log("loading settings... (WIP)");
    }

    public void ExitToMain ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isGamePaused = false;
    }

    public bool isPaused ()
    {
        return isGamePaused;
    }
}
