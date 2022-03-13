using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Windows;

public class AnimationTesting : MonoBehaviour
{
    // The public variables in the scene
    public InputField userPOSText;
    public Camera backGround;
    public PlayLineAnimation playLineAnimation;
    public PlayAnimScript playAnim;
    public Animator inputAnimation;
    public Text blanksRemaining;
    public Text helpUser;
    public Button clickForHelp;
    public AudioSource textGiven;

    // The local variables found in the script
    private int mathRand;
    private string madlibReplacementWord;
    private int blanksRemain = 0;
    private string currentWordPOS;
    private string currentWord;
    private char endOfWord;
    private string[] libWords;
    private int currentIndexOfWord = 0;
    private int currentWordPosition;
    private int endOfWordPosition;
    private System.Random rand = new System.Random();

    public void PlayTheAnimations(string currentWord)
    {
        switch (currentWord)
        {
            case "adjective":
                AdjectiveClick();
                break;
            case "adverb":
                AdverbClick();
                break;
            case "adverb ending in 'ly'":
                AdverbEndingInLyClick();
                break;
            case "noun":
                NounClick();
                break;
            case "plural noun":
                PluralNounClick();
                break;
            case "proper noun":
                ProperNounClick();
                break;
            case "present tense verb":
                PresentTenseVerbClick();
                break;
            default:
                PastTenseVerbClick();
                break;
        }

        helpUser.color = new Color(0, 0, 0, 0);
    }

    public void ActivateField()
    {
        userPOSText.ActivateInputField();
        userPOSText.Select();
        userPOSText.caretPosition = 0;
    }

    public void TextInput()
    {
        playLineAnimation.StopAnimation();
    }

    public void AdverbClick()
    {
        playAnim.PlayAnimAdverb();
    }

    public void AdjectiveClick()
    {
        playAnim.PlayAnimAdjective();
    }

    public void NounClick()
    {
        playAnim.PlayAnimNoun();
    }

    public void PluralNounClick()
    {
        playAnim.PlayAnimPluralNoun();
    }

    public void ProperNounClick()
    {
        playAnim.PlayAnimProperNoun();
    }

    public void AdverbEndingInLyClick()
    {
        playAnim.PlayAnimAdverbEndingInLy();
    }

    public void PresentTenseVerbClick()
    {
        playAnim.PlayAnimPresentTenseVerb();
    }

    public void PastTenseVerbClick()
    {
        playAnim.PlayAnimPastTenseVerb();
    }

    // Start is called before the first frame update
    void Start()
    {
        backGround.backgroundColor = DataManager.backGroundColor;
        helpUser.color = new Color(0, 0, 0, 0);

        Debug.Log("Certainly getting here!");

        libWords = DataManager.lastLibWithBlanks.Split(' ');

        for (int i = 0; i < libWords.Length - 1; i++)
        {
            if (libWords[i][0].ToString() == "_")
            {
                blanksRemain++;
            }
        }

        currentWordPOS = DataManager.lastLibPOS[currentIndexOfWord];
        PlayTheAnimations(currentWordPOS);
        blanksRemaining.text = "Blanks Remaining: " + blanksRemain.ToString();
        inputAnimation.SetBool("Entered", true);
    }

    public void NextWord()
    {
        Debug.Log("Def getting here:  " + userPOSText.text);
        if (Input.GetKeyDown(KeyCode.Return) && userPOSText.text != null)
        {
            if (blanksRemain >= 0)
            {
                Debug.Log("Def getting here lolmao:  " + userPOSText.text);
                textGiven.Play();
                Debug.Log("Def getting here sdfggeff:  " + userPOSText.text);
                madlibReplacementWord = userPOSText.text;
                Debug.Log("Def getting here sdfgsdfg:  " + userPOSText.text);
                currentWordPosition = DataManager.lastLibBlankIndicies[currentIndexOfWord];
                Debug.Log("Def getting here sdfgdsg:  " + userPOSText.text);
                endOfWordPosition = libWords[currentWordPosition].Length - 1;
                Debug.Log("Def getting here sgdas:  " + userPOSText.text);
                endOfWord = libWords[currentWordPosition][endOfWordPosition];
                Debug.Log("Def getting here sdfg:  " + userPOSText.text);

                string replaceEnd = null;
                int x = 0;

                Debug.Log("Def getting here sddfffsddssdfg:  " + userPOSText.text);
                
                if (char.ToString(endOfWord) != "_")
                {
                    do
                    {
                        replaceEnd += libWords[currentWordPosition][endOfWordPosition - x].ToString();
                        Debug.Log("Def getting here sddfffsddssdfg:  " + replaceEnd);
                        x++;
                    }
                    while (libWords[currentWordPosition][endOfWordPosition - x].ToString() != "_");
                }

                Debug.Log("Def getting here xD:  " + userPOSText.text);

                if (replaceEnd != null)
                {
                    madlibReplacementWord += replaceEnd;
                }

                libWords[currentWordPosition] = libWords[currentWordPosition].Replace(libWords[currentWordPosition], madlibReplacementWord);

                blanksRemain--;
                blanksRemaining.text = "Blanks Remaining: " + blanksRemain.ToString();
                currentIndexOfWord += 1;

                Debug.Log("Def getting here lalma:  " + userPOSText.text);

                if (blanksRemain > 0)
                {
                    currentWordPOS = DataManager.lastLibPOS[currentIndexOfWord];
                    PlayTheAnimations(currentWordPOS);
                }
                else
                {
                    for (int i = 0; i < libWords.Length; i++)
                    {
                        DataManager.newLib += libWords[i] + " ";
                    }

                    SceneManager.LoadScene(6);
                }

                Debug.Log("Def getting here bruh:  " + userPOSText.text);

                playLineAnimation.PlayAnim();
            }
        }
        else
        {
            Debug.Log("Certainly getting here! The users text is: " + userPOSText.text);
            Debug.Log("Text Field Cannot be empty!");
        }
    }

    public void GiveHelp()
    {
        switch (playAnim.flipping_ANIM.GetInteger("NumPOS"))
        {
            case 1:
                // Noun
                helpUser.text = "Place or thing (banana, Mount Everest, Banana Mountain, etc...)";
                break;
            case 2:
                // Adjective
                helpUser.text = "Describing word (red, hairy, stinky, etc...)";
                break;
            case 3:
                // Adverb
                helpUser.text = "Modifying word (very, super, sometimes, etc...)";
                break;
            case 4:
                // Proper Noun
                helpUser.text = "Person, group or corporation (Mr. James, PepsiCo, Democrat/Republican, etc...)";
                break;
            case 5:
                // Plural Noun
                helpUser.text = "Multiple places or things (Planets, Aliens, Alien Planets, etc...)";
                break;
            case 6:
                // Present Tense Verb
                helpUser.text = "Action word (stop, drop, roll, etc...)";
                break;
            case 7:
                // Past Tense Verb
                helpUser.text = "Past tense action word (stopped, dropped, rolled, etc...)";
                break;
            default:
                // Adverb Ending In Ly
                helpUser.text = "Modifying word that ends in 'ly' (truly, honestly, rarely, etc...)";
                break;
        }

        helpUser.color = new Color(0, 0, 0, 1);
    }
}
