using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                text = subtitles[currentTextNum].line;
                currentTextNum += 1;
            }
        }
    }
}
