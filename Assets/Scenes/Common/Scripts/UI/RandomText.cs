using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomText : MonoBehaviour
{
    public string[] listOfMessages;
    public Text textToChange;

    // Start is called before the first frame update
    void Start()
    {
        textToChange.text = GetRandomMessage();
    }

    string GetRandomMessage()
	{
        string final;

        final = listOfMessages[Random.Range(0, listOfMessages.Length)];

        return final;
	}
}
