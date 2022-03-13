using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickAnimation : MonoBehaviour
{
    public ButtonClick buttonClick;
    private bool setFalse;

    public void ResetText()
    {
        if (setFalse == true)
            buttonClick.ResetTextColor();
        setFalse = false;
    }   

    // Start is called before the first frame update
    void Start()
    {
        setFalse = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
