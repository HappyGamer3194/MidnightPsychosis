using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class Notifications : MonoBehaviour
{
    public GameObject watch;
    public GameObject statRings;
    public TextMeshProUGUI noti;

    public string[] day1 = new string[5] {"Time to go to bed.", "Remember to drink water.", "Time to go to bed.", "Your heart rate is increasing", "Time to go to bed."};
    public int notiNum = 0;

    public void Ping ()
    {
        statRings.SetActive(false);
        noti.text = day1[notiNum];
        watch.transform.localScale = new Vector3(2, 2, 1);
        /*Task.Delay(3000);

        statRings.SetActive(true);
        noti.text = "";
        watch.transform.localScale = new Vector3(1, 1, 1);*/

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            Ping();
            notiNum++;
        }
    }
}
