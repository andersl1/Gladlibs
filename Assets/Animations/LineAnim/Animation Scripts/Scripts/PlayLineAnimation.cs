using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLineAnimation : MonoBehaviour
{
    public Animator playAnimLine;
    public Animator playSweepLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StopAnimation()
    {
        playAnimLine.SetTrigger("PlayLine");
        playAnimLine.SetBool("StayLine", false);
        playAnimLine.SetBool("Close", false);
    }

    public void StopClosingLine()
    {
        playAnimLine.SetBool("Close", false);
    }

    public void PlayAnim()
    {
        playSweepLine.SetTrigger("Sweep");
    }

    public void SetOff()
    {
        playAnimLine.SetBool("Close", true);
        playAnimLine.SetBool("StayLine", true);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playAnimLine.SetTrigger("PlayLine");
            playAnimLine.SetBool("StayLine", false);
        }
    }
}
