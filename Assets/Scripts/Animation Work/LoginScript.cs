using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class LoginScript : MonoBehaviour
{
    public Animator lineAnimation;
    public Button registerHere;
    public Button loginButton;
    public Text username;
    public Text password;
    public InputField passwordInput;
    public Text errorMessage;
    private Color black = new Color(0, 0, 0, 1);
    private string loginFilePath = @"http://andersonlawrence.net/main/Gladlibs/Build/login.php";

    public void CallLogin()
    {
        StartCoroutine(LogUserIn());
    }

    IEnumerator LogUserIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", passwordInput.text);
        WWW www = new WWW(loginFilePath, form);
        yield return www;

        if (www.text != null && www.text[0] == '0')
        {
            DataManager.username = username.text;
            DataManager.level = int.Parse(www.text.Split('\t')[1]);
            DataManager.isAudio = true;
            SceneManager.LoadScene(2);
        }
        else
        {
            errorMessage.text = www.text;
            errorMessage.color = black;
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAnimationUsername()
    {
        lineAnimation.SetBool("Login", true);
        lineAnimation.SetBool("Password", false);
    }

    public void PlayAnimationPassword()
    {
        lineAnimation.SetBool("Login", false);
        lineAnimation.SetBool("Password", true);
    }

    public void PlayNeitherAnimation()
    {
        lineAnimation.SetBool("Login", false);
        lineAnimation.SetBool("Password", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //lineAnimation.SetTrigger("ExitTrigger");
        errorMessage.color = new Color(0, 0, 0, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DataManager.FullScreen();
        }
    }
}
