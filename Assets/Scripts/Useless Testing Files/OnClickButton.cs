using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClickButton : MonoBehaviour
{
    private Color darkOrange = new Color(1, 0.6f, 0.4f, 1);
    private Color lightOrange = new Color(0.996f, 0.847f, 0.694f, 1);
    private Color orange = new Color(1, 0.4f, 0.2f, 1);
    private double totalHeight;
    private double totalWidth;
    private double xPos;
    private double yPos;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        totalHeight = CameraHeight.height;
        totalWidth = CameraHeight.width;
        timeElapsed = .15f;
        gameObject.GetComponent<TMP_Text>().color = new Color(0, 0, 0, 1);
    }

    void Update()
    {
        yPos = Input.mousePosition.y;
        xPos = Input.mousePosition.x;

        // If the play button is clicked, change the color for .15 seconds (if highlighted change as well), and check if the game type is single or multiplayer.
        // If is multiplayer, then change the game type to multiplayer: otherwise, change to single player. 
        //  && totalWidth / xPos >= 1.615 && totalWidth / xPos <= 1.85
        if (totalHeight / yPos <= 5.41 && totalHeight / yPos >= 3.836)
        {
            Debug.Log("You're there!");
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(MoveDown());

                if (ChangeGameTypeButton.gameTypeIsSingle)
                {
                    SceneManager.LoadScene("EnterText");
                    Debug.Log("The game type is Single");
                }
                else
                {
                    Debug.Log("The game type is Multi");
                }

                gameObject.GetComponent<TMP_Text>().color = darkOrange;
            }

            // The highlight color of the play button is light orange. 
            else
            {
                gameObject.GetComponent<TMP_Text>().color = lightOrange;
            }
        }

        // The normal color of the play button is orange.
        else
        {
            gameObject.GetComponent<TMP_Text>().color = orange;
        }
    }

    // This is the coroutine for changing the color of the button on click.
    IEnumerator MoveDown()
    {
        timeElapsed = .15f;
        while (timeElapsed > 0)
        {
            gameObject.GetComponent<TMP_Text>().color = darkOrange;
            timeElapsed -= Time.deltaTime;
            yield return null;
        }
    }
}
