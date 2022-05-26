using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Mr Tuohy Friendly Mode")]
    public static bool mrTuohyFriendlyMode;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ToggleMrTuohyFriendlyMode()
    {
        mrTuohyFriendlyMode = !mrTuohyFriendlyMode;
    }
}