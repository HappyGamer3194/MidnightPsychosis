using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Notifications : MonoBehaviour
{
    public GameObject watch;
    public Text noti;

    public string[] day1;
    public int notiNum = 0;
    private int notiNumTemp = -1;

    public void Ping()
    {
        noti.text = day1[notiNum];
    }

    // Update is called once per frame
    void Update()
    {
        if (!(notiNum == notiNumTemp))
        {
            Ping();
            notiNumTemp = notiNum;
        }
    }

    public void NotiComplete()
    {

    }
}
