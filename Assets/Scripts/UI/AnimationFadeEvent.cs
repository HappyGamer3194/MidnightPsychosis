using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFadeEvent : MonoBehaviour
{
    public GameManager gamemanager;
    void FadeisOver(bool done)
    {
        gamemanager.deathScreen.SetActive(true);
    }
}
