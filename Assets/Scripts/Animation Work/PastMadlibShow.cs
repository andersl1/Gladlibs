using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PastMadlibShow : MonoBehaviour
{
    public Text userLibText;
    public Text copyText;
    public Text goToMenuText;
    public Animator clipboard;
    public Animator clipboardElements;
    public Camera backGround;
    public AudioSource menuClicked;
    public AudioSource copyClicked;

    private TextEditor copyToClipboard = new TextEditor();

    // Start is called before the first frame update
    void Start()
    {
        backGround.backgroundColor = DataManager.backGroundColor;
        userLibText.text = DataManager.pastLibToShow;
        clipboard.SetBool("Entering", true);
        clipboardElements.SetBool("Entering", true);
        clipboard.SetBool("Exiting", false);
        clipboardElements.SetBool("Exiting", false);
    }

    public void EraseWords()
    {
        copyText.text = "";
        goToMenuText.text = "";
        userLibText.text = "";
    }

    public void GoToMenu()
    {
        menuClicked.Play();
        clipboard.SetBool("Exiting", true);
        clipboardElements.SetBool("Exiting", true);
    }

    public void CopyText()
    {
        copyClicked.Play();
        copyToClipboard.text = userLibText.text;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }
}
