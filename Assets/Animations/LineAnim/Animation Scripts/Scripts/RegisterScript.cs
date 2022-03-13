using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class RegisterScript : MonoBehaviour
{
    public Animator animationLinesImage;
    public Animator lineAnimation;
    public Button loginHere;
    public Button registerButton;
    public Text registerButtonText;
    public TMP_Text haveAnAccountText;
    public Text usernamePlaceholder;
    public Text username;
    public InputField passwordInput;
    public InputField passwordAgainInput;
    public Text password;
    public Text passwordAgain;
    public Text errorMessage;
    private Color black = new Color(0, 0, 0, 1);
    private bool isEmail;
    private string registerFilePath = @"http://andersonlawrence.net/main/Gladlibs/Build/registration.php";
    public void ResetText()
    {
        registerButtonText.text = "Log in";
        haveAnAccountText.text = "Don't have an account? Register here.";
        usernamePlaceholder.text = "Username";
    }

    public void UndoResetText()
    {
        registerButtonText.text = "Register";
        haveAnAccountText.text = "Already have an account? Login here.";
        usernamePlaceholder.text = "Username";
    }
    public void CallRegister()
    {
        isEmail = true;

        if (passwordAgainInput.text != passwordInput.text)
        {
            errorMessage.text = "The passwords don't match.";
            errorMessage.color = black;
        }
        else if (passwordInput.text.Length < 8)
        {
            errorMessage.text = "Password is not long enough.";
            errorMessage.color = black;
        }
        else if (isEmail == true)
        {
            for (int i = 0; i < passwordInput.text.Length; i++)
            { 
                if (char.IsLetter(passwordInput.text[i]) == false)
                {
                    StartCoroutine(RegisterUser());

                    if (i == passwordInput.text.Length)
                    {
                        errorMessage.text = "Password must include a symbol or number.";
                        errorMessage.color = black;
                    }
                }
            }
        }
    }

    IEnumerator RegisterUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", passwordInput.text);

        WWW www = new WWW(registerFilePath, form);
        yield return www;

        if (www.text != null && www.text[0] == '0')
        {
            DataManager.username = username.text;
            DataManager.level = 1;
            DataManager.isAudio = true;
            SceneManager.LoadScene(2);
        }
        else
        {
            errorMessage.text = www.text;
            errorMessage.color = new Color(0, 0, 0, 1);
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void GoToLogin()
    {
        lineAnimation.SetBool("Entering", false);
    }

    public void PlayAnimationUsername()
    {
        animationLinesImage.SetBool("Login", true);
        animationLinesImage.SetBool("Password", false);
        animationLinesImage.SetBool("PasswordAgain", false);
    }

    public void PlayAnimationPassword()
    {
        animationLinesImage.SetBool("Login", false);
        animationLinesImage.SetBool("Password", true);
        animationLinesImage.SetBool("PasswordAgain", false);
    }

    public void PlayAnimationAgainPassword()
    {
        animationLinesImage.SetBool("Login", false);
        animationLinesImage.SetBool("Password", false);
        animationLinesImage.SetBool("PasswordAgain", true);
    }

    public void PlayNeitherAnimation()
    {
        animationLinesImage.SetBool("Login", false);
        animationLinesImage.SetBool("Password", false);
        animationLinesImage.SetBool("PasswordAgain", false);
    }


    // Start is called before the first frame update
    void Start()
    {
        DataManager.FullScreen();
        lineAnimation.SetTrigger("EnterTrigger");
        lineAnimation.SetBool("Entering", true);
        errorMessage.color = new Color(0, 0, 0, 0);
    }
}
