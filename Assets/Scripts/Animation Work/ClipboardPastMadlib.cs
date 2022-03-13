using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClipboardPastMadlib : MonoBehaviour
{
    public PastMadlibShow pastMadlibShow;
   
    public void EraseWords()
    {
        pastMadlibShow.EraseWords();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
