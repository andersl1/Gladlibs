using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class FinalLib : MonoBehaviour
{
    // The objects within this scene.
    public Button nextButton;
    public TMP_Text showTheLibFinal;
    public Button copyTextButton;
    public AudioSource nextPage;
    private TextEditor copyToClipboard = new TextEditor();

    // Copy the text to the clipboard
    public void CopyText()
    {
        copyToClipboard.text = showTheLibFinal.text;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();

        if (DataManager.isAudio)
        {
            nextPage.volume = 1;
            nextPage.Play();
        }
        else
        {
            nextPage.volume = 0;
        }
    }

    // Return Home after next button is clicked
    public void GoHome()
    {
        SceneManager.LoadScene(9);
    }

    // Start is called before the first frame update
    // Test if the user is logged in. If so, continue, and add the text to the DataManager. Otherwise, send them to login screen.
    void Start()
    {
        if (DataManager.LoggedIn)
        {
            showTheLibFinal.text = DataManager.newLib;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
