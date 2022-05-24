using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCover : MonoBehaviour
{
    public GameObject subtitles;

    // Update is called once per frame
    void Update()
    {
        if (subtitles.GetComponent<Subtitles>().currentTextNum == 2)
        {
            gameObject.SetActive(false);
        }
    }
}
