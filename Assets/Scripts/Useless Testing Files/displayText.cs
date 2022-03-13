using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class displayText : MonoBehaviour
{
    static List<string> listOfValuesFromUser = valuesFromInput.inputFromUser;
    int lengthOfArray = listOfValuesFromUser.Count;
    public Text listDisplayed;
    string thisString;

    // Start is called before the first frame update
    void Start()
    {
        listDisplayed = GameObject.Find("Text").GetComponent<Text>();

        for (int i = 0; i < lengthOfArray; i++)
        {
            thisString += listOfValuesFromUser[i] + " ";
        }

        listDisplayed.text = thisString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
