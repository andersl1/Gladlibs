using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PastLibs : MonoBehaviour
{
    public Text libFirst;
    public Text libSecond;
    public Text libThird;
    public Text libFourth;
    public Text libFifth;
    public Text libSixth;
    public Image firstImage;
    private string receivedMadlibFilePath = @"http://andersonlawrence.net/main/Gladlibs/Build/receivedmadlibs.php";

    public void OpenLibs()
    {
        StartCoroutine(GetLibData());
    }

    public void FirstPastMadlib()
    {
        if (libFirst.text != "")
            DataManager.pastLibToShow = libFirst.text;
            SceneManager.LoadScene(7);
    }

    public void SecondPastMadlib()
    {
        if (libSecond.text != "")
            DataManager.pastLibToShow = libSecond.text;
            SceneManager.LoadScene(7);
    }

    public void ThirdPastMadlib()
    {
        if (libThird.text != "")
            DataManager.pastLibToShow = libThird.text;
            SceneManager.LoadScene(7);
    }   

    public void FourthPastMadlib()
    {
        if (libFourth.text != "")
            DataManager.pastLibToShow = libFourth.text;
            SceneManager.LoadScene(7);
    }

    public void FifthPastMadlib()
    {
        if (libFifth.text != "")
            DataManager.pastLibToShow = libFifth.text;
            SceneManager.LoadScene(7);
    }
    public void SixthPastMadlib()
    {
        if (libSixth.text != "")
            DataManager.pastLibToShow = libSixth.text;
            SceneManager.LoadScene(7);
    }

    IEnumerator GetLibData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DataManager.username);

        Debug.Log(DataManager.username);
        WWW www = new WWW(receivedMadlibFilePath, form);
        yield return www;

        string[] strings = www.text.Split('\t');

        if (strings[0] == "0")
        {
            int x = 2;
            do
            {
                if ((strings.Length > x) && null != strings[x] && strings[x].ToString() != "")
                {
                    switch (x)
                    {
                        case 2:
                            libFirst.text = strings[x].ToString();
                            break;
                        case 3:
                            libSecond.text = strings[x].ToString();
                            break;
                        case 4:
                            libThird.text = strings[x].ToString();
                            break;
                        case 5:
                            libFourth.text = strings[x].ToString();
                            break;
                        case 6:
                            libFifth.text = strings[x].ToString();
                            break;
                        default:
                            libSixth.text = strings[x].ToString();
                            break;
                    }
                }

                x++;
            }
            while (x < 8);

        }
        else
        {
            Debug.Log("Error: " + www.text);
        }
    }
}
