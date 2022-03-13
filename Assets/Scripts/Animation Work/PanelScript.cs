using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelScript : MonoBehaviour
{
    public Animator panel;
    public RegisterScript loginText;

    public void LoadLogin()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLoginText()
    {
        loginText.ResetText();
    }

    public void ResetRegisterText()
    {
        loginText.UndoResetText();
    }
}
