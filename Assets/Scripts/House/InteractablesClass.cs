using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactables
{
    public GameObject interactable;
    public Animator animator;

    [Header("Portability")]
    public bool portable;

    [ConditionalHide("portable", true)]
    public Transform startingLocation;
    [ConditionalHide("portable", true)]
    public Vector3 offset;
}