using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TestingScript : MonoBehaviour
{
    public Button gameMode;
    public Button PlayGame;
    public Button backButton;
    public Camera backGround;
    public Text gameModeText;
    public Text userName;
    public TMP_InputField userMadlibInput;
    public Animator paperAnimation;
    public Animator testingScriptAnim;
    public Animator topClipboard;
    public Animator playButton;
    public AudioSource backpressed;
    public AudioSource playpressed;
    public Text errorMessage;

    private string insertlibFilePath = @"http://andersonlawrence.net/main/Gladlibs/Build/insertmadlibs.php";
    private float timer;
    private float sizeDecrease;
    private float sizeIncrease;
    private Vector3 posGameMode;
    private Vector3 posPlay;
    private Vector3 reset;
    private Color nonExistant = new Color(0, 0, 0, 0);

    public void PlayTheGame()
    {
        playpressed.Play();
        if (userMadlibInput.text.Length <= 25 || userMadlibInput.text.Length >= 600)
        {
            if (userMadlibInput.text.Length <= 25)
            {
                errorMessage.color = new Color(0, 0, 0, 1);
                Debug.Log("To few characters!");
            }
            else
            {
                errorMessage.text = "Too Many Characters (limit 600).";
                errorMessage.color = new Color(0, 0, 0, 1);
                Debug.Log("Too many characters! Limit is 600.");
            }
        }
        else
        {
            testingScriptAnim.SetBool("Disappear", true);
            paperAnimation.SetBool("Disappear", true);
            topClipboard.SetBool("Disappear", true);
            playButton.SetBool("Disappear", true);
        }
    }

    public void RemoveError()
    {
        errorMessage.color = new Color(0, 0, 0, 0);
    }

    public void StartSubmit()
    {
        StartCoroutine(SubmitMadLib());
    }

    public void PlayTopClipboard()
    {
        topClipboard.SetBool("Active", true);
        topClipboard.SetBool("Inactive", false);
    }

    public void ExitTopClipboard()
    {
        topClipboard.SetBool("Active", false);
        topClipboard.SetBool("Inactive", true);
    }

    public void GoBack()
    {
        backpressed.Play();
        testingScriptAnim.SetBool("GoBack", true);
        playButton.SetBool("Decrease", true);
        ExitPaper();
        ExitTopClipboard();
    }

    public void PlayPaper()
    {
        paperAnimation.SetBool("Active", true);
        paperAnimation.SetBool("Inactive", false);
    }

    public void EndOpacity()
    {
        PlayGame.image.color = nonExistant;
        userMadlibInput.image.color = nonExistant;
        userName.color = nonExistant;
        gameMode.image.color = nonExistant;
        backButton.image.color = nonExistant;
    }


    public void ExitPaper()
    {
        paperAnimation.SetBool("Active", false);
        paperAnimation.SetBool("Inactive", true);
    }

    public void GameModeShrink()
    {
        PlayGame.image.rectTransform.sizeDelta = new Vector2(1687.634f, 155.43f);
        gameMode.image.rectTransform.sizeDelta = new Vector2(1687.634f, 155.43f);
        gameMode.transform.position = reset;
        StartCoroutine(ShrinkButton());
    }
    public void SizeButton()
    {
        StartCoroutine(FontIncrease());
    }

    IEnumerator FontIncrease()
    {
        timer = 1.0f;
        gameModeText.text = "Single Player";
        for (int i = 0; i <= timer; timer -= .025f)
        {
            if (gameModeText.fontSize <= 103)
            {
                gameModeText.fontSize += 2;
            }

            yield return new WaitForSeconds(.01055f);
        }
    }

    public void ResizeButton()
    {
        StartCoroutine(FontChange());
    }

    IEnumerator FontChange()
    {
        timer = 1.0f;
        gameModeText.text = "Single Player";
        for (int i = 0; i <= timer; timer -= .025f)
        {
            if (gameModeText.fontSize >= 10)
            {
                gameModeText.fontSize -= 2;
            }

            yield return new WaitForSeconds(.015f);
        }
    }

    IEnumerator ShrinkButton()
    {
        timer = 1.0f;
        sizeDecrease = 155.439f;
        sizeIncrease = sizeDecrease;
        posGameMode = gameMode.transform.position;
        posPlay = PlayGame.transform.position;

        for (int i = 0; i <= timer; timer -= .025f)
        {
            // For the bottom button to increase in size
            if (sizeIncrease < 228f)
            {
                posPlay.y += 1.1f;
                sizeIncrease += 2.2f;
            }

            // For the top button to decrease in size
            posGameMode.y -= .36f;
            sizeDecrease -= 4f;

            // Setting values of rectangle transform
            PlayGame.image.rectTransform.sizeDelta = new Vector2(1687.634f, sizeIncrease);
            gameMode.image.rectTransform.sizeDelta = new Vector2(1687.634f, sizeDecrease);

            // Setting values of position transform
            PlayGame.transform.position = posPlay;
            gameMode.transform.position = posGameMode;

            // To include a "smushing" effect onto the words of the button
            gameModeText.fontSize -= 4;
            yield return new WaitForSeconds(.01f);
        }
    }

    public void EnableButton()
    {
        backButton.enabled = true;
    }

    public void SetAnimOff()
    {
        //testingScriptAnim.SetBool("SetOff", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.LoggedIn)
        {
            errorMessage.color = new Color(0, 0, 0, 0);
            backGround.backgroundColor = DataManager.backGroundColor;
            backButton.enabled = false;
            playButton.SetBool("Idle", true);
            playButton.SetTrigger("Enter");
            reset = gameMode.transform.position;
            PlayPaper();
            PlayTopClipboard();
            userName.text = DataManager.username;
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }

    // Insert the madlib into the database using the insertmadlibs.php file
    IEnumerator SubmitMadLib()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DataManager.username);
        form.AddField("madlib", userMadlibInput.text);

        WWW www = new WWW(insertlibFilePath, form);
        yield return www;

        if (www.text == "0")
        {
            DataManager.lastLib = userMadlibInput.text;
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("Error: " + www.text);
        }
    }
}
