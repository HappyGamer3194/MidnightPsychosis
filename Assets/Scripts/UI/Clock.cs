using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    Text textClock;

    public float rate;

    public bool start;

    public float startHour;
    public float startMinute;
    public float currentHour;
    float currentMinute;

    void Start()
    {
        textClock = GetComponent<Text>();

        currentHour = startHour;
        currentMinute = startMinute;
    }

    void Update()
    {
        string hour = LeadingZero((int)currentHour);
        string minute = LeadingZero(((int)currentMinute));

        textClock.text = hour + ":" + minute;

        if (start == true)
        {
            currentMinute += Time.deltaTime * rate;

            if (currentMinute > 59)
            {
                currentMinute = 0;
                currentHour = currentHour + 1;
            }
        }

    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}