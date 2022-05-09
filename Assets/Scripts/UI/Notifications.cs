using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Notifications : MonoBehaviour
{
    public GameObject watch;
    public Text noti;
    public AudioSource newNoti;
    public AudioSource NotiCompleted;

    public string[] day1;
    public int notiNum = 0;
    private int notiNumTemp = 0;

    //AudioSource sound = newNoti.GetComponent<AudioSource>();

    public void Ping()
    {
        noti.text = day1[notiNum];
        newNoti.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!(notiNum == notiNumTemp))
        {
            StartCoroutine(Pause());
        }
    }

    IEnumerator Pause()
    {
        NotiCompleted.Play();
        Debug.Log("test 1");
        yield return new WaitForSeconds(3);
        Debug.Log("test 2");
        Ping();
        notiNumTemp = notiNum;
    }
}
