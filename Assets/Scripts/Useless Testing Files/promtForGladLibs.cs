using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class promtForGladLibs : MonoBehaviour
{
    private static string giveStringToDisplay = "";
    private static string[] firstRowInArray;
    private static string[] wordReplacements;
    public static string[,] textForShow;
    public static int testForZero = 0;
    public static int numberPrompts = 0;
    public static bool enterPressing;

    // Start is called before the first frame update
    void Start()
    {
        numberPrompts = 0;
        enterPressing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            giveStringToDisplay = GameObject.Find("InputField").GetComponent<InputField>().text;

            if (giveStringToDisplay.Length > 1)
            {
                firstRowInArray = giveStringToDisplay.Split(' ');
                textForShow = new string[3, firstRowInArray.Length];

                foreach (string word in firstRowInArray)
                {
                    Debug.Log(word + " ");
                }

                for (int i = 0; i < firstRowInArray.Length; i++)
                {
                    textForShow[0, i] = firstRowInArray[i];
                }

                testForZero = 1;
                Debug.Log(giveStringToDisplay);
            }
            else
            {
                textForShow[0, 0] = "Thats weird, you didnt give enough words!";
            }
        }

        if (testForZero >= 1 && showGladLibs.arrayHasBeenCreated)
        {
            if (numberPrompts == 0)
            {
                wordReplacements = new string[showGladLibs.numberPrompts];
            }

            showGladLibs.m_displayLibs.text = showGladLibs.m_displayedArray[1, numberPrompts];
            
            if (Input.GetKeyDown(KeyCode.Return) && enterPressing == false && numberPrompts < showGladLibs.numberPrompts)
            {
                giveStringToDisplay = GameObject.Find("InputField").GetComponent<InputField>().text;
                Debug.Log(giveStringToDisplay);
                wordReplacements[numberPrompts] = giveStringToDisplay;

                showGladLibs.m_displayedArray[2, numberPrompts] = giveStringToDisplay;
                numberPrompts++;
                enterPressing = true;
            }
        }
    }
}
