using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TMP_InputField passwordAgain;
    public Text errorMessage;
    public Button backButton;

    public Button registerButton;

    // Two states: exist and not. If the text should be displayed, set the color to existant. Otherwise, set it to nonExistant.
    private Color nonExistant = new Color(0, 0, 0, 0);
    private Color existant = new Color(0, 0, 0, 1);

    // Go back to the main login screen on back button click.
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    // Automatically set the errormessage to nonExistant since no error has arisen yet. 
    public void Start()
    {
        errorMessage.fontSize = 45;
        errorMessage.color = nonExistant;
    }

    // Send this information to register.php
    public void CallRegister()
    {
        StartCoroutine(Registration());
        Debug.Log("Got here 1");
    }

    // Add their username and password into the database (if not exists already). If successful, send the username to DataManager to store the user's sesssion information.
    IEnumerator Registration()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        Debug.Log("Got here 2");
        WWW www = new WWW("http://localhost/sqlconnect/registration.php", form);
        Debug.Log("Got here 3");
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully");
            SceneManager.LoadScene(3);
        }
        else
        {
            errorMessage.text = www.text;
            errorMessage.fontSize = 35;
            errorMessage.color = existant;
            Debug.Log("No user created. Error " + www.text);
        }
    }

    // Only allow the button log in to be interactable if they have the proper requirements.
    public void Verify()
    {
        registerButton.interactable = (username.text.Length >= 6 && password.text.Length >= 8 && passwordAgain.text.Length >= 8);
        errorMessage.color = nonExistant;
    }

    // Test if the two passwords correspond with each other. 
    public void VerifyPasswords()
    {
        if (registerButton.interactable)
        {
            if (passwordAgain.text != password.text)
            {
                Debug.Log("Passwords do not match!");
                Debug.Log(passwordAgain.text + " password again");
                Debug.Log(password.text + " password");
                errorMessage.text = "Passwords don't match!";
                errorMessage.color = existant;
                registerButton.interactable = false;
            }
            else
            {
                errorMessage.color = nonExistant;
                Debug.Log("All set!");
            }
        }
    }
}
