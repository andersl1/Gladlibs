using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text displayUser;

    // Display the previous user that was logged in
    private void Start()
    {
        {
            if (DataManager.LoggedIn)
            {
                displayUser.text = "Player: " + DataManager.username;
            }
        }
    }

    // Go to register on button click
    public void goToRegister()
    {
        SceneManager.LoadScene(1);
    }

    // Go to login on button click
    public void goToLogin()
    {
        SceneManager.LoadScene(2);
    }
}
