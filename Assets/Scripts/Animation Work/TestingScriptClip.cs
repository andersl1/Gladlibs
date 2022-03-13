using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScriptClip : MonoBehaviour
{
    public TestingScript testingScript;

    public void ReSizeButton()
    {
        testingScript.ResizeButton();
        //testingScript.ResizeButton();
    }

    public void SizeButton()
    {
        testingScript.SizeButton();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(2);
    }

    public void End()
    {
        testingScript.EndOpacity();
    }


    public void ShrinkButton()
    {
        //testingScript.GameModeShrink();
    }

    public void StartLib()
    {
        testingScript.StartSubmit();
    }

    public void StopAnimation()
    {
        testingScript.EnableButton();
        //testingScript.SetAnimOff();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
