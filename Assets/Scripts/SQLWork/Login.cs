using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TMP_Text errorMessage;
    public Button loginButton;
    public Button backButton;
    private Color nonExistant = new Color(0, 0, 0, 0);
    private Color existant = new Color(0, 0, 0, 1);

    // Go to the main screen for users to see both buttons: register and log in.
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    // Don't show the error message (no user with that name) if the passwords match and/or they haven't put in a password yet. 
    void Start()
    {
        errorMessage.color = nonExistant;
        loginButton.interactable = false;
    }

    // Upon clicking login, send the SQL queries via PHP to test if the user has entered a correct username and password.
    public void CallLogin()
    {
        StartCoroutine(LogUserIn());
        Debug.Log("Got here 1");
    }

    // Log the user in. WWW.text is the echo from PHP (if not 0 then something has gone wrong).
    // Then send them to the main screen. Otherwise, tell them the error and that their login had failed.
    IEnumerator LogUserIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        Debug.Log(username.text);
        Debug.Log(password.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;

        Debug.Log(www.text);

        if (www.text != null && www.text[0] == '0')
        { 
            DataManager.username = username.text;
            DataManager.level = int.Parse(www.text.Split('\t')[1]);
            DataManager.isAudio = true;
            Debug.Log("User login failed. Error #" + www.text);
            SceneManager.LoadScene(14);
        }
        else
        {
            errorMessage.text = www.text;
            errorMessage.color = existant;
            Debug.Log("User login failed. Error #" + www.text);
        }
        Debug.Log("Got here 3");
    }

    // Don't allow the log in button to be pressed if they don't have the required material.
    public void Verify()
    {
        loginButton.interactable = (username.text.Length >= 6 && password.text.Length >= 8);
        errorMessage.color = nonExistant;
    }
}
