using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeText : MonoBehaviour
{
    public Text my_text;
    public float currentAmountOfTime = 4;
    // Start is called before the first frame update
    void Start()
    {
        my_text = GameObject.Find("Text").GetComponent<Text>();
        my_text.text = "Press";
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmountOfTime > 0)
        {
            currentAmountOfTime -= Time.deltaTime;
        }
        else 
        {
            currentAmountOfTime = 4;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("ChooseGameType");
        }

        if (currentAmountOfTime >= 0 && currentAmountOfTime < 1)
        {
            my_text.text = "Smash";
        }
        else if (currentAmountOfTime >= 1 && currentAmountOfTime < 2)
        {
            my_text.text = "Punch";
        }
        else if (currentAmountOfTime >= 2 && currentAmountOfTime < 3)
        {
            my_text.text = "Kick";
        }
        else
        {
            my_text.text = "Press";
        }
    }
}
