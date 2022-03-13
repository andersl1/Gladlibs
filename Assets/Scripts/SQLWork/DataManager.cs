using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager 
{
    // Store these values for the session
    public static string username;
    public static int level;
    public static string lastLib;
    public static string lastLibWithBlanks;
    public static int[] lastLibBlankIndicies;
    public static string[] lastLibPOS;
    public static string newLib;
    public static bool isAudio;
    public static string pastLibToShow;
    public static Color backGroundColor;
    public static bool SoundOn;
    public static bool firstTime;

    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }

    public static void FullScreen()
    {
        Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true, 30);
        Screen.fullScreen = !Screen.fullScreen;
    }
}
