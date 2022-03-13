using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDelete : MonoBehaviour
{
    public Text userText;
    public AnimationTesting setTextNull;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TextDeletion()
    {
        Debug.Log("Getting HEre!");
        setTextNull.userPOSText.text = "";
        setTextNull.ActivateField();
        userText.color = new Color(1, 1, 1, 0);
    }

    public void TextReset()
    {
        Debug.Log("Getting HEre!");
        Debug.Log("Um: " + userText.text);
        userText.color = new Color(0, 0, 0, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
