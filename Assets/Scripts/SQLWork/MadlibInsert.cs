using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MadlibInsert : MonoBehaviour
{
    public TMP_InputField userMadLib;
    public Button submitButton;
    public TMP_Text usernameDisplay;
    public Button backButton;
    private string insertFilePath = @"http://andersonlawrence.net/main/Gladlibs/Build/insertmadlibs.php";
    // On backbutton click: go back to the main screen.
    public void GoBack()
    {
        SceneManager.LoadScene(9);
    }

    // On button click submission: send the madlib to the database.
    public void OnSubmission()
    {
        StartCoroutine(SubmitMadLib());
    }

    // Insert the madlib into the database using the insertmadlibs.php file
    IEnumerator SubmitMadLib()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DataManager.username);
        form.AddField("madlib", userMadLib.text);

        Debug.Log(DataManager.username);
        Debug.Log(userMadLib.text);
        WWW www = new WWW(insertFilePath, form);
        yield return www;

        if (www.text == "0")
        {
            DataManager.lastLib = userMadLib.text;
            Debug.Log("Safely saved. " + www.text);
            SceneManager.LoadScene(6);
        }
        else
        {
            Debug.Log("Error: " + www.text);
        }
    }

    // Test if the user is logged in, if so, display their name!
    private void Awake()
    {
        if (DataManager.LoggedIn)
        {
            usernameDisplay.text = "\n\tName: " + DataManager.username;
            usernameDisplay.color = new Color(1, .1f, .1f, 1);
        }
        else
        {
            SceneManager.LoadScene(0);
            Debug.Log("Error: No user signed in");
        }
    }
}
