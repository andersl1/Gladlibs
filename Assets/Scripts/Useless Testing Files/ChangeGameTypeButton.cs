using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGameTypeButton : MonoBehaviour
{
    private Button btn;
    public static bool gameTypeIsSingle;

    void Start()
    {
        gameTypeIsSingle = true;
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        if (gameTypeIsSingle)
        {
            gameTypeIsSingle = false;
        }
        else
        {
            gameTypeIsSingle = true;
        }

        Debug.Log(gameTypeIsSingle);
    }
}
