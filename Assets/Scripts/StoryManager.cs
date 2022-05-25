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
        if (trigger[trigNum].activeSelf == false)
        {
            trigger[trigNum].SetActive(true);
        }
        if (trigger[trigNum].GetComponent<Trigger>().entered == true)
        {
            trigger[trigNum].SetActive(false);

            //If the next trigger is the end of the array, stop incrementing
            if (trigNum + 1 != trigger.Length)
            {
                trigNum += 1;
            }
        }

        if (animations[animationNum].trigger.entered == true && finished == false)
        {
            if (animations[animationNum].audio != null && animations[animationNum].audio.isPlaying == false)
            {
                if (GameObject.Find("GameManager").GetComponent<GameManager>().mrTuohyFriendlyMode == false)
                {
                   animations[animationNum].audio.Play(0);
                }

                finished = true;
            }

            animations[animationNum].objectToBeAnimated.SetBool("Activate", true);

            if (animationNum +1 != animations.Length)
            {
                animationNum += 1;
            }
        }
    }
}