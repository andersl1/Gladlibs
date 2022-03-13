using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSweep : MonoBehaviour
{
    public SpriteRenderer sweepingAnim;
    public TextDelete textToDelete;
    public PlayLineAnimation setBoolFalse;
    
    // Start is called before the first frame update
    void Start()
    {
        sweepingAnim.color = new Color(1, 1, 1, 0);
    }

    public void TurnOn()
    {
        sweepingAnim.color = new Color(1, 1, 1, 1);
    }

    public void EraseWords()
    {
        textToDelete.TextDeletion();
    }

    public void TurnOff()
    {
        sweepingAnim.color = new Color(1, 1, 1, 0);
        setBoolFalse.SetOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
