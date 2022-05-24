using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[System.Serializable]
public class StoryAnimations
{
    public string name;
    public Trigger trigger;
    public Animator objectToBeAnimated;
    public AudioSource audio;
}
