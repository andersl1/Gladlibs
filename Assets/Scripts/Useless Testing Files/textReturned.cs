using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class textReturned : MonoBehaviour
{
    // Initialize my variables
    static string stringToReturn;
    static string thisString = "?";
    int valueInArray = 0;
    public static bool enterPressed = false;
    public static Text thisText;
    KeyCode thisCharPressed;
    string setValue;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InputField>().text == "" && valueInArray > 0) 
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode))
                    {
                        thisCharPressed = kcode;
                    }
                }

                setValue = thisCharPressed.ToString();
                GetComponent<InputField>().text += setValue;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("ShowResult");
        }

        // Check if the enter button was pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Enterpressed is now true: enter was pressed so add the string into values and increment the value in the array
            enterPressed = true;
            stringToReturn = GetComponent<InputField>().text;
            thisString = stringToReturn;
            valuesFromInput.inputFromUser.Add(thisString);
            Debug.Log("The array at " + valueInArray + " is equal to: " + valuesFromInput.inputFromUser[valueInArray]);
            valueInArray += 1;
            GetComponent<InputField>().text = "";
            GetComponent<InputField>().caretPosition = 1;
            i = 0;
            Debug.Log(thisString);
        }
        else
        {
            enterPressed = false;
        }
    }
}
