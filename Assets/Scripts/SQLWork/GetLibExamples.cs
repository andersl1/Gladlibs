using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using UnityEditor;

public class GetLibExamples : MonoBehaviour
{
    // The objects within the scene: the four copy buttons, the audio source, the strings that are copied to clipboard and 
    // the back button.
    public AudioSource copyAudio;
    public Button backButton;
    public Button copyButton1;
    public Button copyButton2;
    public Button copyButton3;
    public Button copyButton4;
    private string stringToCopy;
    private TextEditor copyToClipboard = new TextEditor();

    // On button clicked: copy the first text: if audio was turned off, do not play sound.
    public void CopyFirstText()
    {
        if (DataManager.isAudio)
        {
            copyAudio.volume = 1;
            copyAudio.Play();
        }
        else
        {
            copyAudio.volume = 0;
        }
        stringToCopy = "The next day, when Jack woke up in the morning and looked out of the window," + 
            " he saw that a huge beanstalk had grown from his magic beans! He climbed up the beanstalk and reached a kingdom in the sky. There lived a giant and his wife.";
        copyToClipboard.text = stringToCopy;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }

    // On button clicked: copy the second text: if audio was turned off, do not play sound.
    public void CopySecondText()
    {
        if (DataManager.isAudio)
        {
            copyAudio.volume = 1;
            copyAudio.Play();
        }
        else
        {
            copyAudio.volume = 0;
        }
        stringToCopy = "So he huffed and he puffed and he blew the house down! The wolf was greedy and he tried to catch both pigs at once, but he was too greedy and got neither! "  + 
            "His big jaws clamped down on nothing but air and the two little pigs scrambled away as fast as their little hooves would carry them.";
        copyToClipboard.text = stringToCopy;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }

    // On button clicked: copy the third text: if audio was turned off, do not play sound.
    public void CopyThirdText()
    {
        if (DataManager.isAudio)
        {
            copyAudio.volume = 1;
            copyAudio.Play();
        }
        else
        {
            copyAudio.volume = 0;
        }
        stringToCopy = "But when the hunter had taken Snow White out into the forest and thought to kill her, she was so beautiful that his heart failed him, and he let her go, " + 
            "telling her she must not, for his sake and for her own, return to the King's palace.";
        copyToClipboard.text = stringToCopy;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }

    // On button clicked: copy the fourth text: if audio was turned off, do not play sound.
    public void CopyFourthText()
    {
        if (DataManager.isAudio)
        {
            copyAudio.volume = 1;
            copyAudio.Play();
        }
        else
        {
            copyAudio.volume = 0;
        }
        stringToCopy = "But the old cook had been running so hard that she was not able to stop herself any better than the cat had done, " +
            "and she fell right on top of the mixed up dog and cat, so that all three rolled over on the walk in a heap together.";
        copyToClipboard.text = stringToCopy;
        copyToClipboard.SelectAll();
        copyToClipboard.Copy();
    }

    // If back button is pressed, return to the menu screen
    public void GoBack()
    {
        SceneManager.LoadScene(9);
    }
}
