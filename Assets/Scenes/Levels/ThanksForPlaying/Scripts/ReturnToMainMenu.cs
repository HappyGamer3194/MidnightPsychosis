using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForSeconds());
    }

    IEnumerator waitForSeconds()
    {
        yield return new WaitForSeconds(20);

        SceneManager.LoadScene(0);
    }
}
