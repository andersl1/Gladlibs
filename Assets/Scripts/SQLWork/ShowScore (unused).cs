using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowScore : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text username;
    public Button raiseScore;
    public Button quitGame;

    private void Awake()
    {
        if (DataManager.LoggedIn)
        {
            username.text = "Player: " + DataManager.username;
            score.text = "Score: " + DataManager.level.ToString();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void SaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DataManager.username);
        form.AddField("lvl", DataManager.level);

        WWW www = new WWW("http://localhost/sqlconnect/saveddata.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Safely saved.");
        }
        else
        {
            Debug.Log("Error: " + www.text);
        }

        DataManager.LogOut();
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        DataManager.level++;
        score.text = "Score: " + DataManager.level.ToString();
    }

    // Start is called before the first frame update
    /*IEnumerator Start()
    {
        WWW webRequest = new WWW("");
        yield return webRequest;
        string[] shownText = webRequest.text.Split('\t');
        string displayedString = "";
        foreach (string word in shownText)
        {
            displayedString += " " + word;
        }

        Debug.Log(displayedString);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

}
