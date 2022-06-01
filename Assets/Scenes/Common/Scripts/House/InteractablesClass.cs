using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactables
{
    public GameObject interactable;
    public GameObject trigger;
    public Animator animator;

    //Freezes player on object interaction
    [Header("Freeze State")]
    public bool freezeState;
    [Tooltip("Position the player will freeze in")]
    public Vector3 freezePosition;
    [Tooltip("How long the transition should be, 1 < time; 0.1 > time")]
    public float freezeTransition;
    public float freezeDuration;

    //Changes objects material
    [Header("Material")]
    public bool changeSprite;
    public Sprite sprite;
    public GameObject spriteToChange;

    //Checks if the object is able to be picked up
    [Header("Portability")]
    public bool portable;
    public Vector3 endingLocation;
    public Vector3 offset;
    public float pickupTime;
    public bool bringToTrigger;
    public Transform bringTrigger;
    public GameObject portabilityTrigger;
}