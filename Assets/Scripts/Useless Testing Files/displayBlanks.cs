using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayBlanks : MonoBehaviour
{
    public Text blanksDisplayed;
    private string[] toBlank;
    private int thisInt;
    private int i = 0;
    public bool wasEnterPressed;
    private static int numberOfPOS;

    // Start is called before the first frame update
    void Start()
    {
        blanksDisplayed = GameObject.Find("DisplayTextPOS").GetComponent<Text>();
        blanksDisplayed.text = "Thats cool that this works";
        thisInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        wasEnterPressed = getUserPOS.enterPressed;

        if (showGladLibs.arrayHasBeenCreated)
        {
            if (thisInt == 0)
            {
                toBlank = new string[numberOfPOS];
                thisInt++;
            }

            if (wasEnterPressed)
            {
                toBlank[i] = showGladLibs.m_displayedArray[1, i];
                i++;
            }

            blanksDisplayed.text = toBlank[i];
        }
    }
}