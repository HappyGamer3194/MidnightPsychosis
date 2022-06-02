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
        if (trigger != null)
        {
            if (trigger[trigNum].activeSelf == false)
            {
                trigger[trigNum].SetActive(true);
            }
            if (trigger[trigNum].GetComponent<Trigger>().entered == true)
            {

                //If the next trigger is the end of the array, stop incrementing
                if (trigNum + 1 != trigger.Length)
                {
                    trigNum += 1;
                }
            }
        }
        if (animations[animationNum].ifLookAt == false)
        {
            if (animations[animationNum].trigger.entered == true && finished == false)
            {
                if (animations[animationNum].audio != null && animations[animationNum].audio.isPlaying == false && animations[animationNum].audio != null)
                {
                    if (GameManager.mrTuohyFriendlyMode == false)
                    {
                        if (animations[animationNum].pauseAudio == false)
                        {
                            animations[animationNum].audio.Play(0);
                        } else
                        {
                            Debug.Log("audio paused");
                            animations[animationNum].audio.Pause();
                        }
                    }
                    finished = true;
                }

                if (animations[animationNum].objectToBeAnimated != null)
                {
                    animations[animationNum].objectToBeAnimated.GetComponent<Animator>().SetBool("Activate", true);
                }

                if (animationNum +1 != animations.Length)
                {
                    animationNum += 1;
                }
            }
        } else
        {
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

                    finished = true;
                }

                if (animations[animationNum].objectToBeAnimated != null)
                {
                    animations[animationNum].objectToBeAnimated.GetComponent<Animator>().SetBool("Activate", true);
                }

                if (animationNum + 1 != animations.Length)
                {
                    animationNum += 1;
                }
            }
        }
    }
}