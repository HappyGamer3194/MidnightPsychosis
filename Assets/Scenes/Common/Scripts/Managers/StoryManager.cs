using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public GameObject[] trigger;
    public int trigNum;

    public StoryAnimations[] animations;
    public int animationNum;
    bool finished;

    // Update is called once per frame
    void Update()
    {
        if (animations[animationNum].ifLookAt == false)
        {
            finished = false;
            if (animations[animationNum].trigger.entered == true && finished == false)
            {
                if (animations[animationNum].audio != null && animations[animationNum].audio.isPlaying == false && animations[animationNum].audio != null)
                {
                    if (GameManager.mrTuohyFriendlyMode == false)
                    {
                        if (animations[animationNum].pauseAudio == false)
                        {
                            Debug.Log("play play play");
                            animations[animationNum].audio.Play(0);
                        }
                    }
                    if (animations[animationNum].pauseAudio == true)
                    {
                        Debug.Log("audio paused");
                        animations[animationNum].audio.Pause();
                    }
                    finished = true;
                }

                if (animations[animationNum].objectToBeAnimated != null)
                {
                    Debug.Log("playing Animation");
                    animations[animationNum].objectToBeAnimated.GetComponent<Animator>().SetBool("Activate", true);
                } else
                {
                    if (animationNum + 1 != animations.Length)
                    {
                        Debug.Log("no animation, skipping...");
                        animationNum += 1;
                    }
                }

                if (animationNum +1 != animations.Length)
                {
                    animationNum += 1;
                }
            }
        } else
        {
            finished = false;
            if (animations[animationNum].objectMesh.GetComponent<MeshRenderer>().isVisible && finished == false && animations[animationNum].trigger.entered == true)
            {
                if (animations[animationNum].audio != null && animations[animationNum].audio != null)
                {
                    if (GameManager.mrTuohyFriendlyMode == false)
                    {
                        if (animations[animationNum].pauseAudio == false)
                        {
                            animations[animationNum].audio.Play(0);
                        } else
                        {
                            animations[animationNum].audio.Pause();
                        }
                    }
                }

                if (animations[animationNum].objectToBeAnimated != null)
                {
                    animations[animationNum].objectToBeAnimated.GetComponent<Animator>().SetBool("Activate", true);
                }

                if (animationNum + 1 != animations.Length)
                {
                    animationNum += 1;
                }
                finished = true;
            }
        }
    }
}