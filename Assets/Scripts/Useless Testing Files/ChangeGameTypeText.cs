using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeGameTypeText : MonoBehaviour
{
    private bool displaySingle;
    private static TMP_Text gameType;

    // Start is called before the first frame update
    void Start()
    {
        gameType = this.GetComponent<TMP_Text>();
        gameType.text = "Single Player";
        displaySingle = true;
    }

    // Update is called once per frame
    void Update()
    {
        displaySingle = ChangeGameTypeButton.gameTypeIsSingle;

        if (!displaySingle)
        {
            gameType.text = "Multi Player";
        }
        else
        {
            gameType.text = "Single Player";
        }
    }
}
