using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetInfo : MonoBehaviour
{
    public Button backButton;
    public Text showInfo;

    // Show the user this text so that they have a better understanding of what the game is.
    private void Start()
    {
        showInfo.text = "Hi there! Welcome to Gladlibs. \nTo play, click the play button in the main menu screen. Afterwards, you will be prompted to input a text: the text you choose is completely up to you!\n" +
            "The game will then randomly generate blanks from the words that make up the text. You'll be prompted for words that correspond to a part of speech (noun, adjective, adverb, etc...): so give it your funniest shot! \n\n" + 
            "Parts of Speech: \nNoun: person, place, or thing.\nAdjective: a word that describes another. \nAdverb: Modifies an adjective. \nProper Noun: A name (company, person or people).";
    }

    // Go back to the main screen.
    public void goBack()
    {
        SceneManager.LoadScene(9);
    }
}
