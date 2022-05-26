using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[System.Serializable]
public class StoryAnimations
{
    public string name;
    public Trigger trigger;
    public bool ifLookAt;
    public GameObject objectToBeAnimated;
    public GameObject objectMesh;
    public AudioSource audio;
}
