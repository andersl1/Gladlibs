using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLine : MonoBehaviour
{
    public TextDelete textToDelete;
    public PlayLineAnimation setBoolFalse;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void LineEnd()
    {
        setBoolFalse.StopClosingLine();
    }

    public void ResetText()
    {
        textToDelete.TextReset();
        setBoolFalse.StopAnimation();
    }

    public void ShowWords()
    {
        textToDelete.TextReset();
    }

    // Update is called once per frame
    void Update()
    {
    }

}
