using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public AudioSource onButtonClickTopPanel;
    public AudioSource onButtonClickMiddlePanel;
    public AudioSource onButtonClickPlayPanel;
    public Button soundControl;
    public Button colorControl;
    public Camera backGround;
    public Animator information; 
    public Animator openExamples;
    public Animator quitMenu;
    public Animator pastMadlibData;
    public Button gameMode;
    public Button PlayGame;
    public Button exampleMadlibs;
    public Button goBackToLogin;
    public Button pastMadlibs;
    public Button info;
    public Text exampleMadlibsText;
    public Text goBackToLoginText;
    public Text pastMadlibsText;
    public Text infoText;
    public Text gameModeText;
    public Text username;
    public PastLibs pastLibs;
    public AudioSource soundTrack;
    public SoundTrack volumeControl;
    public Text firstTextToCopy;
    public Text secondTextToCopy;
    public Text thirdTextToCopy;
    public Text fourthTextToCopy;

    private float timer;
    private float decrement;
    private Color newColor;
    private Color fontColor;
    private bool isDaytime = false;
    private TextEditor copyToClipboard = new TextEditor();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DataManager.FullScreen();
        }
    }

    // Will have to create an object for the sound script because it needs to not LAYER.
    public void SwapLightSprite()
    {
        if (!isDaytime)
        {
            onButtonClickTopPanel.Play();
            backGround.backgroundColor = new Color(46 / 255f, 30 / 255f, 25 / 255f, 1);
            DataManager.backGroundColor = backGround.backgroundColor;
            colorControl.image.sprite = colorControl.spriteState.pressedSprite;
            isDaytime = true;
        }
        else 
        {
            onButtonClickTopPanel.Play();
            backGround.backgroundColor = new Color(207 / 255f, 180 / 255f, 155 / 255f, 1);
            DataManager.backGroundColor = backGround.backgroundColor;
            colorControl.image.sprite = colorControl.spriteState.disabledSprite;
            isDaytime = false;
        }
    }

    public void SwapSoundSprite()
    {
        if (DataManager.SoundOn)
        {
            onButtonClickTopPanel.Play();
            soundControl.image.sprite = soundControl.spriteState.pressedSprite;
            DataManager.SoundOn = false;
        }
        else
        {
            onButtonClickTopPanel.Play();
            DataManager.SoundOn = true;
            soundControl.image.sprite = soundControl.spriteState.disabledSprite;
        }
    }

    public void openPastLibs()
    {
        onButtonClickMiddlePanel.Play();
        pastMadlibData.SetBool("ExitInfo", false);
        pastMadlibData.SetBool("EnterInfo", true);
        pastLibs.OpenLibs();
    }   
    
    public void ClosePastMadlibs()
    {
        onButtonClickMiddlePanel.Play();
        pastMadlibData.SetBool("EnterInfo", false);
        pastMadlibData.SetBool("ExitInfo", true);
    }

    public void openInformation()
    {
        onButtonClickMiddlePanel.Play();
        PlayGame.enabled = false;
        information.SetBool("EnterInfo", true);
        information.SetBool("ExitInfo", false);
    }

    public void exitInformation()
    {
        onButtonClickMiddlePanel.Play();
        PlayGame.enabled = true;
        information.SetBool("EnterInfo", false);
        information.SetBool("ExitInfo", true);
    }
 
    public void copyOne()
    {
        onButtonClickMiddlePanel.Play();
        copyToClipboard.text = firstTextToCopy.text;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }

    public void copyTwo()
    {
        onButtonClickMiddlePanel.Play();
        copyToClipboard.text = secondTextToCopy.text;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }

    public void copyThree()
    {
        onButtonClickMiddlePanel.Play();
        copyToClipboard.text = thirdTextToCopy.text;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }

    public void copyFour()
    {
        onButtonClickMiddlePanel.Play();
        copyToClipboard.text = fourthTextToCopy.text;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }

    public void openMadlibExamples()
    {
        onButtonClickMiddlePanel.Play();
        PlayGame.enabled = false;
        openExamples.SetBool("EnterInfo", true);
        openExamples.SetBool("ExitInfo", false);
    }

    public void exitMadlibExamples()
    {
        onButtonClickMiddlePanel.Play();
        PlayGame.enabled = true;
        openExamples.SetBool("EnterInfo", false);
        openExamples.SetBool("ExitInfo", true);
    }

    public void GoToLogin()
    {
        onButtonClickMiddlePanel.Play();
        PlayGame.enabled = false;
        quitMenu.SetBool("Clicked", true);
        quitMenu.SetBool("GoBack", false);
    }

    public void CancelLogout()
    {
        onButtonClickMiddlePanel.Play();
        PlayGame.enabled = true;
        quitMenu.SetBool("GoBack", true);
        quitMenu.SetBool("Clicked", false);
    }

    public void Logout()
    {
        onButtonClickMiddlePanel.Play();
        SceneManager.LoadScene(4);
    }

    public void SwitchGame()
    {
        if (gameModeText.text == "Single Player")
        {
            onButtonClickMiddlePanel.Play();
            gameModeText.text = "Multi Player";
        }
        else
        {
            onButtonClickMiddlePanel.Play();
            gameModeText.text = "Single Player";
        }
    }

    public void SwitchPage()
    {
        if (gameModeText.text == "Single Player")
        {
            onButtonClickPlayPanel.Play();
            StartCoroutine(Shrink());
        }
    }

    public void ResetTextColor()
    {
        StartCoroutine(ResetColor());
    }

    IEnumerator ResetColor()
    {
        timer = 1f;
        for (int i = 0; i < timer; timer -= .0125f)
        {
            // As timer nears zero, so does decrement: this color opacity slowly goes down to zero
            decrement = System.Math.Abs(timer - 1);
            newColor = new Color(214/255f, 139/255f, 82/255f, decrement);
            fontColor = new Color(0, 0, 0, decrement);

            // The color of the text and background of the first button goes slowly to zero
            goBackToLogin.image.color = newColor;
            goBackToLoginText.color = fontColor;

            // The color of the text and background of the second button goes slowly to zero
            exampleMadlibs.image.color = newColor;
            exampleMadlibsText.color = fontColor;

            // The color of the text and background of the third button goes slowly to zero
            pastMadlibs.image.color = newColor;
            pastMadlibsText.color = fontColor;

            // The color of the text and background of the fourth button goes slowly to zero
            info.image.color = newColor;
            infoText.color = fontColor;

            yield return new WaitForSeconds(.0005f);
        }
    }


    IEnumerator Shrink()
    {
        timer = 1f;
        for (int i = 0; i < timer; timer -=.0125f)
        {
            // As timer nears zero, so does decrement: this color opacity slowly goes down to zero
            decrement = timer;
            newColor = new Color(goBackToLogin.image.color.r, goBackToLogin.image.color.g, goBackToLogin.image.color.b, decrement);
            fontColor = new Color(0, 0, 0, decrement);

            // The color of the text and background of the first button goes slowly to zero
            goBackToLogin.image.color = newColor;
            goBackToLoginText.color = fontColor;

            // The color of the text and background of the second button goes slowly to zero
            exampleMadlibs.image.color = newColor;
            exampleMadlibsText.color = fontColor;

            // The color of the text and background of the third button goes slowly to zero
            pastMadlibs.image.color = newColor;
            pastMadlibsText.color = fontColor;

            // The color of the text and background of the fourth button goes slowly to zero
            info.image.color = newColor;
            infoText.color = fontColor;
          
            yield return new WaitForSeconds(.0005f);
        }

        if (decrement <= .01f)
        {
            SceneManager.LoadScene(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.LoggedIn)
        {
            username.text = DataManager.username;

            if (DataManager.firstTime != true)
            {
                soundTrack.Play();
                DataManager.SoundOn = true;
            }
            else
            {
                if (!DataManager.SoundOn)
                {
                    soundControl.image.sprite = soundControl.spriteState.pressedSprite;
                }
            }

            if (DataManager.backGroundColor.a == 1)
            {
                backGround.backgroundColor = DataManager.backGroundColor;

                if (DataManager.backGroundColor.r > .5f)
                {
                    colorControl.image.sprite = colorControl.spriteState.disabledSprite;
                    isDaytime = false;
                }
                else
                {
                    colorControl.image.sprite = colorControl.spriteState.pressedSprite;
                    isDaytime = true;
                }
            }
            else
            {
                backGround.backgroundColor = new Color(207 / 255f, 180 / 255f, 155 / 255f, 1);
                DataManager.backGroundColor = backGround.backgroundColor;
            }

            DataManager.firstTime = true;
        }
        else
        {

            SceneManager.LoadScene(4);
        }
    }
}
