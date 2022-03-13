using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayButton : MonoBehaviour
{
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(printHello);
    }

    void printHello()
    {
        Console.WriteLine("Hello World!");
        SceneManager.LoadScene("PlayState");
        Debug.Log("You forgot something I think");
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
