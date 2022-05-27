using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Animations;

public class Notifications : MonoBehaviour
{
    public Text noti;
    public AudioSource newNoti;
    public AudioSource NotiCompleted;
    public Animation cautionPopUp;

    public string[] day1;
    public int notiNum = -1;
    private int notiNumTemp = -1;
    public bool wait = false;

    public void Ping()
    {
        noti.text = day1[notiNum];
        noti.GetComponent<Text>().color = Color.white;
        newNoti.Play();
        cautionPopUp.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (notiNum != notiNumTemp && !wait)
        {
            StartCoroutine(NotiComplete());
        }
    }

    IEnumerator NotiComplete()
    {
        wait = true;
        if (notiNum != 0)
        {
            if (day1[notiNum - 1] != "" && notiNum != 0)
            {
                NotiCompleted.Play();
                noti.GetComponent<Text>().color = Color.green;
                if (day1[notiNum] != "")
                {
                    yield return new WaitForSeconds(3);
                }
            }
        }
        if (day1[notiNum] != "")
        {
            Ping();
        }
        notiNumTemp = notiNum;
        wait = false;
    }
}
