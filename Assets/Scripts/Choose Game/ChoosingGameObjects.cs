using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChoosingGameObjects : MonoBehaviour
{
    public AudioSource nextPage;
    public TMP_Text usernameDisplay;
    public Text comingSoon;
    private Color existant = new Color(1f, .7f, .4f, 1);
    private Color nonExistant = new Color(0, 0, 0, 0);
    public Button infoButton;
    public Button changeAudio;
    public Button helpButton;
    public Button switchMode;
    public TMP_Text playerMode;
    public TMP_Text playText;
    public Camera main;
    public Button backButton;

    // Change the audio: upon clicking this button, turn the volume off and on depending on its previous state. Store this value in DataManager. 
    public void ChangeAudio()
    {
        if (DataManager.isAudio)
        {
            DataManager.isAudio = false;
            nextPage.volume = 0;
        }
        else
        {
            nextPage.volume = 1;
            DataManager.isAudio = true;
        }
    }

    // Go to the info screen upon clicking this button.
    public void goToInfo()
    {
        SceneManager.LoadScene(10);
    }

    // Go to the example screen upon clicking this button.
    public void goToExamples()
    {
        SceneManager.LoadScene(11);
    }

    // Go to the Play screen upon clicking this button if the mode is single player.
    public void PlaySingle()
    {
        if (playerMode.text == "Single Player")
        {
            SceneManager.LoadScene(5);
        }
    }

    // Go back to login screen.
    public void goBack()
    {
        SceneManager.LoadScene(2);
    }

    // Switch the game mode and play the audio upon clicking "next" button.
    public void clickGameMode()
    {
        OnClickGameMode();
    }

    public void OnClickGameMode()
    {
        if (DataManager.isAudio)
        {
            nextPage.Play();
        }
        if (playerMode.text == "Single Player")
        {
            playerMode.text = "Multi Player";
        }
        else
        {
            playerMode.text = "Single Player";
        }
    }
    
    // Start is called before the first frame update
    // Test for log in and display the user's name on the screen 
    void Start()
    {
        usernameDisplay.text = null;
        if (!DataManager.LoggedIn)
        {
            usernameDisplay.text = "No user logged in";
            Debug.Log("Error: no user signed in.");
            usernameDisplay.text = DataManager.username;
            SceneManager.LoadScene(0);
        }
        else
        {
            usernameDisplay.text = DataManager.username;
        }
        playerMode.text = "Single Player";
    }

    // Update is called once per frame
    // Do not show the text if the mode is on Single Player, otherwise, show it since the mode hasn't been created yet. 
    void Update()
    {
       if (playerMode.text == "Multi Player")
       {
            comingSoon.color = existant;
       }
       else
       {
            comingSoon.color = nonExistant;
       }
    }
}
