using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

public class ShowLibScript : MonoBehaviour
{
    public Button menuButton;
    public Button copyText;
    public Text userMadlibText;
    public Animator clipboard;
    public Animator background;
    public Camera backGroundCamera;
    public AudioSource topButtonClicked;
    public AudioSource bottomButtonClicked;

    private string pastMadlibFilePath = @"http://andersonlawrence.net/main/Gladlibs/Build/insertpastlibs.php";
    private string newString;
    private TextEditor copyToClipboard = new TextEditor();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Data: " + DataManager.newLib);
        for (int i = 0; i < DataManager.newLib.Length; i++)
        {
            if (i >= 1)
            {
                if (!Char.IsPunctuation(DataManager.newLib[i]))
                {
                    newString += DataManager.newLib[i - 1];
                }
            }
        }
        DataManager.newLib = null;
        DataManager.newLib = newString;
        Debug.Log("The value of newString is: " + newString);
        backGroundCamera.backgroundColor = DataManager.backGroundColor;
        userMadlibText.text = null;
        userMadlibText.text = DataManager.newLib + "\n\n\n" + DataManager.lastLib;
        clipboard.SetBool("Entering", true);
        background.SetBool("Entering", true);
    }

    public void GoToMenu()
    {
        bottomButtonClicked.Play();
        StartCoroutine(InsertLib());
    }

    IEnumerator InsertLib()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DataManager.username);
        form.AddField("blanklib", DataManager.newLib);
        form.AddField("madlib", DataManager.lastLib);

        WWW www = new WWW(pastMadlibFilePath, form);
        yield return www;
        
        if (www.text == "0")
        {
            SceneManager.LoadScene(2);
            DataManager.newLib = null;
        }
        else
        {
            Debug.Log("Oops! There was an error: " + www.text);
        }
    }

    public void CopyText()
    {
        topButtonClicked.Play();
        copyToClipboard.text = userMadlibText.text;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }
}
