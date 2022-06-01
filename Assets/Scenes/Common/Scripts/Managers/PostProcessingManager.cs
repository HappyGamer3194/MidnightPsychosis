using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    public Volume postProcessing;

    public float defaultVignetteIntensity;
    public float monsterVignetteIntensity;
    public float defaultVignetteSmoothness;
    public float monsterVignetteSmoothness;
    public float vignetteSpeed;

    bool lookingAtMonster;

    public void PostProcessingCheck()
    {
        Vignette vignette;

        if (lookingAtMonster == true)
        {
            if (postProcessing.profile.TryGet<Vignette>(out vignette))
            {
                vignette.smoothness.value = Mathf.Lerp(vignette.smoothness.value, monsterVignetteSmoothness, vignetteSpeed);
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, monsterVignetteIntensity, vignetteSpeed);
            }
        }
        else
        {
            if (postProcessing.profile.TryGet<Vignette>(out vignette))
            {
                vignette.smoothness.value = Mathf.Lerp(vignette.smoothness.value, defaultVignetteSmoothness, vignetteSpeed);
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, defaultVignetteIntensity, vignetteSpeed);

            }
        }
    }
}
