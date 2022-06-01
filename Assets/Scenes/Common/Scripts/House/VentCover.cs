using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCover : MonoBehaviour
{
    public GameObject subtitles;
    public float textNum;

    // Update is called once per frame
    void Update()
    {
        if (subtitles.GetComponent<Subtitles>().currentTextNum == textNum)
        {
            gameObject.SetActive(false);
        }
    }
}
