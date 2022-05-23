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
    [ConditionalHide("freezeState", true)]
    [Tooltip("Position the player will freeze in")]
    public Vector3 freezePosition;
    [ConditionalHide("freezeState", true)]
    [Tooltip("How long the transition should be, 1 < time; 0.1 > time")]
    public float freezeTransition;
    [ConditionalHide("freezeState", true)]
    public float freezeDuration;

    //Changes objects material
    [Header("Material")]
    public bool changeMaterial;
    [ConditionalHide("changeMaterial", true)]
    public Material material;

    //Checks if the object is able to be picked up
    [Header("Portability")]
    public bool portable;
    [ConditionalHide("portable", true)]
    public Vector3 endingLocation;
    [ConditionalHide("portable", true)]
    public Vector3 offset;
    [ConditionalHide("portable", true)]
    public float pickupTime;
    [ConditionalHide("portable", true)]
    public bool bringToTrigger;
    [ConditionalHide("portable", true)]
    public Transform bringTrigger;
    [ConditionalHide("portable", true)]
    public GameObject portabilityTrigger;
}