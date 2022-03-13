using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class getUserPOS : MonoBehaviour
{
    public static string thisStringToDisplay;
    public static bool enterPressed = false;
  
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<InputField>().DeactivateInputField();
        thisStringToDisplay = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (showGladLibs.arrayHasBeenCreated)
            {
                GameObject.Find("SecondInputField").GetComponent<InputField>().ActivateInputField();
                thisStringToDisplay = GameObject.Find("SecondInputField").GetComponent<InputField>().text;

                enterPressed = true;
            }
        }
        else
        {
            enterPressed = false;
        }    
    }
}