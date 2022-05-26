using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }

        IEnumerator FlickeringLight()
        {
            isFlickering = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            timeDelay = Random.Range(5f, 10f);
            yield return new WaitForSeconds(timeDelay);
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            timeDelay = Random.Range(1f, 5f);
            yield return new WaitForSeconds(timeDelay);
            isFlickering = false;
        }
    }
}
