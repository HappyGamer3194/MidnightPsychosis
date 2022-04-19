using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    #region CharacterController

    public CharacterController controller;
    public GameObject player;

    float speed;
    float jumpForce;
    public float gravity = -10f;
    public float groundDistance = 0.4f;

    public Transform groundCheck;

    public LayerMask groundMask;

    public bool isGrounded;

    public Vector3 velocity;

    #endregion

    #region Sneaking

    public bool sneaking;
    public bool stand;

    public float walkingSpeed;
    public float sneakingSpeed;
    public float standToSneakSpeed;

    public Vector3 sneakingScale;
    public Vector3 standingScale;

    #endregion

    #region PostProcessing Stuffs

    public Volume postProcessing;

    #region Vignette

    public float vignetteDefaultSmoothness = 0.4f;
    public float vignetteDefaultIntensity = 0.25f;
    public float vignetteSneakingSmoothness = 1f;
    public float vignetteSneakingIntensity = 0.3f;
    public float vignetteSpeed = 0.02f;

    #endregion

    #region Chromatic Aberration

    public float chromaticAberrationSneakingIntensity;
    public float chromaticAberrationDefaultInensity;
    public float chromaticAberrationSpeed;

    #endregion

    #endregion

    // Update is called once per frame
    void Update()
    {
        //CheckSphere checks if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If player is grounded and velocity.y is less than 0 the player can now jump
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = velocity.y + jumpForce;
            }
        }

        //Player gravity
        velocity.y += gravity * Time.deltaTime;

        //Inputs for player movement
        float xInput = Input.GetAxis("Horizontal") * speed;
        float yInput = Input.GetAxis("Vertical") * speed;

        Vector3 move = transform.right * xInput + transform.forward * yInput;
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        //Sneaking Input
        if (Input.GetButton("Sneak"))
        {
            sneaking = true;
        } else
        {
            sneaking = false;
        }

        //Checks if sneaking
        checkSneak();

        //Checks all character modifiers and applies Post Processing
        postProcessingCheck();
    }

    void checkSneak()
    {
        //If sneakng == true
        if (sneaking == true)
        {
            //Set speed to sneakingSpeed and scale the player down linearly to sneakingScale by standToSneakSpeed
            speed = sneakingSpeed;
            player.transform.localScale = Vector3.Lerp(player.transform.localScale, sneakingScale, standToSneakSpeed * Time.deltaTime);
        } else
        {
            stand = true;
            if (stand)
            {
                stand = false;

                //Set speed to walking speed and position the player up linearly as well as scaling the player on a slower rate back to standingScale
                speed = walkingSpeed;
                //player.transform.localPosition = Vector3.Lerp(player.transform.localPosition, new Vector3(player.transform.localPosition.x, standingScale.y, player.transform.localPosition.z), (standToSneakSpeed*2) * Time.deltaTime);
                player.transform.localScale = Vector3.Lerp(player.transform.localScale, standingScale, (standToSneakSpeed/5) * Time.deltaTime);
            }

        }
    }

    void postProcessingCheck()
    {
        Vignette vignette;
        ChromaticAberration chromaticAberration;

        #region Sneaking

        if (sneaking)
        {
            if (postProcessing.profile.TryGet<Vignette>(out vignette))
            {
                vignette.smoothness.value = Mathf.Lerp(vignette.smoothness.value, vignetteSneakingSmoothness, vignetteSpeed);
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, vignetteSneakingIntensity, vignetteSpeed);
            }

            if (postProcessing.profile.TryGet<ChromaticAberration>(out chromaticAberration))
            {
                chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, chromaticAberrationSneakingIntensity, chromaticAberrationSpeed);
            }

        } else
        {
            if (postProcessing.profile.TryGet<Vignette>(out vignette))
            {
                vignette.smoothness.value = Mathf.Lerp(vignette.smoothness.value, vignetteDefaultSmoothness, vignetteSpeed);
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, vignetteDefaultIntensity, vignetteSpeed);
            }

            if (postProcessing.profile.TryGet<ChromaticAberration>(out chromaticAberration))
            {
                chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, chromaticAberrationDefaultInensity, chromaticAberrationSpeed);
            }
        }

        #endregion
    }
}
