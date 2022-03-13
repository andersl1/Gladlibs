using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationGameInfo : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public Animator information;
    public Canvas current;
    public AudioSource buttonClicked;

    public void YesClicked()
    {
        buttonClicked.Play();
        information.SetBool("Exit", true);
    }

    public void DisableCanvas()
    {
        current.enabled = false;
    }
    
    public void NoClicked()
    {
        buttonClicked.Play();
        SceneManager.LoadScene(14);
    }

    // Start is called before the first frame update
    void Start()
    {
        information.SetBool("Enter", true);
    }
}
