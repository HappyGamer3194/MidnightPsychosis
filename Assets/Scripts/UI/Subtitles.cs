using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Subtitles : MonoBehaviour
{
    public SubtitleLines[] subtitles;
    string text;

    public int currentTextNum;

    // Update is called once per frame
    public void Update()
    {
        gameObject.GetComponent<Text>().text = text;

        if (currentTextNum != subtitles.Length)
        {
            if (subtitles[currentTextNum].trigger.entered == true)
            {
                if (subtitles[currentTextNum].sound != null)
                {
                    if (subtitles[currentTextNum].pauseSound == false)
                    {
                        subtitles[currentTextNum].sound.Play(0);
                    } else
                    {
                        subtitles[currentTextNum].sound.Pause();
                    }
                }
                if (subtitles[currentTextNum].line != null)
                {
                    text = subtitles[currentTextNum].line;
                }

                StartCoroutine("blankAfter");
                currentTextNum += 1;
            }
        }
    }

    private IEnumerator blankAfter()
    {
        yield return new WaitForSeconds(10);
        text = " ";
    }
}
