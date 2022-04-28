using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToScene : MonoBehaviour
{
    public string sceneName;
    
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
