using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Allow the user to return home upon clicking this button.
    public Button returnHome;

    // Go home.
    public void goBackHome()
    {
        SceneManager.LoadScene(9);
    }
}
