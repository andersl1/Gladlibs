using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SharpNL;
using SharpNL.Tokenize;
using SharpNL.POSTag;
using System.IO;
using SharpNL.Utility;

public class showGladLibs : MonoBehaviour
{
    // Initialize the variables that are going to get passed into the blank generator
    // m_displayLibs will display this onto a canvas: the text from the user is stored in text variable
    public static Text m_displayLibs;
    private static string[] text;
    private string[,] m_returnedArray = null;
    public static string[,] m_displayedArray;
    private static string m_textToString = "";
    private static int m_lengthOfFirstIndex;

    // Initialize the variables for the Arrays that are going to be returned
    private static string[] wordsBeingReplaced;
    private static string stringReturnedAfterBlanks;
    private static string typeOfPOS;
    private static string debugger;
    private static string[] partsOfSpeechInBlanks;
    private static int randomNumber;
    private static int blankCreationNumber = 1;
    private static System.Random rand = new System.Random();
    private static int listIndex = 0;
    private static string blankReplacement;
    public static bool arrayHasBeenCreated;
    public static int numberPrompts;
    private static int[] indexOfBlanks;
    private static List<string> blankFollowingItems = new List<string>{"'s", "'t", "'ve", "'d", "'re", "“", "?", ".", ":", "\"", "”", "...", ";", ")", ",", "!"};

    // Initialize the tagger and tokenizer to get the POS of the words
    static WhitespaceTokenizer whitespaceTokenizer = WhitespaceTokenizer.Instance;
    private static FileStream fileToOpen = new FileStream(@"C:\Code\OpenNLP_Models\en-pos-maxent.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
    static POSModel model = new POSModel(fileToOpen);
    static POSTaggerME tagger = new POSTaggerME(model);
    static string[] tokenized;
    static string[] tags;

    // Start is called before the first frame update
    void Start()
    {
        m_displayLibs = GameObject.Find("ShowLibsText").GetComponent<Text>();
        m_displayLibs.text = "Hello my friend.";
        arrayHasBeenCreated = false;
        numberPrompts = 0;
        Debug.Log(arrayHasBeenCreated);
    }

    // Update is called once per frame
    void Update()
    {
        if (promtForGladLibs.testForZero == 1)
        {

            m_lengthOfFirstIndex = promtForGladLibs.textForShow.GetLength(1);
            Debug.Log("Len: " + m_lengthOfFirstIndex);
            m_displayedArray = new string[3, m_lengthOfFirstIndex];
            Debug.Log(arrayHasBeenCreated);
            text = new string[m_lengthOfFirstIndex];
            Debug.Log(promtForGladLibs.textForShow[0, 2]);

            for (int i = 0; i < m_lengthOfFirstIndex; i++)
            {
                text[i] = promtForGladLibs.textForShow[0, i];
                m_textToString += text[i] + " ";
            }

            m_displayedArray = randomBlankGenerator(m_textToString, m_lengthOfFirstIndex);
            arrayHasBeenCreated = true;

            do
            {
                numberPrompts++;
            }
            while (m_displayedArray[0, numberPrompts] != null);

            Debug.Log("Numba: " + numberPrompts);

            Debug.Log("Len: " + m_displayedArray[2, 0]);
            promtForGladLibs.testForZero = 2;
            Debug.Log(m_displayLibs.text);
            Debug.Log(m_textToString);
        }
    }

    string[,] randomBlankGenerator(string textToGenerate, int lengthOfText)
    {
        partsOfSpeechInBlanks = new string[lengthOfText];
        wordsBeingReplaced = new string[lengthOfText];
        m_returnedArray = new string[3, lengthOfText];
        indexOfBlanks = new int[lengthOfText];
        int randomChance = 6;
        randomNumber = rand.Next(1, randomChance);
        stringReturnedAfterBlanks = "";
        debugger = "";

        tokenized = whitespaceTokenizer.Tokenize(textToGenerate);
        tags = tagger.Tag(tokenized);
        int numberOfBlankReplacements = 0;
        int sizeOfTokens = tokenized.Length;
        string currentTag;

        Debug.Log("There are " + sizeOfTokens + " tokens");
        
        for (int i = 0; i < tags.Length; i++)
        {
            debugger += tags[i] + " ";
        }

        Debug.Log("The word " + tokenized[0] + " contains " + tokenized[0][0] + " at the 1st index.");
        Debug.Log(debugger);
        
        for(int i = 0; i < sizeOfTokens; i++)
        {
            Debug.Log("Current word: " + tokenized[i] + " is a(n) " + tags[i] + "\n\n\n\n");
            if (listIndex < (sizeOfTokens))
            {
                listIndex++;
            }

            if (randomNumber == blankCreationNumber)
            {
                currentTag = tags[i];

                if (currentTag == "NN")
                {
                    typeOfPOS = "noun";
                }
                else if (currentTag == "VB")
                {
                    typeOfPOS = "present tense verb";
                }
                else if (currentTag == "VBN")
                {
                    typeOfPOS = "past tense verb";
                }
                else if (currentTag == "NNP")
                {
                    typeOfPOS = "proper noun";
                }
                else if (currentTag == "NNS")
                {
                    typeOfPOS = "plural noun";
                }
                else if (currentTag == "RB")
                {
                    typeOfPOS = "adverb ending in 'ly'";
                }
                else if (currentTag == "JJ")
                {
                    typeOfPOS = "adjective";
                }
                else
                {
                    typeOfPOS = "None";
                }

                Debug.Log("The word " + tokenized[i] + " is a(n) " + typeOfPOS);

                if (typeOfPOS != "None" && tokenized[i].Length > 4)
                {
                    Debug.Log(tokenized[i] + " is a good word because it is a(n) " + typeOfPOS);
                    wordsBeingReplaced[numberOfBlankReplacements] = tokenized[i];
                    partsOfSpeechInBlanks[numberOfBlankReplacements] = typeOfPOS;
                    indexOfBlanks[numberOfBlankReplacements] = i;

                    Debug.Log("The word being replaced here is: " + wordsBeingReplaced[numberOfBlankReplacements]);
                    Debug.Log("The POS being replaced here is: " + partsOfSpeechInBlanks[numberOfBlankReplacements]);
                    blankReplacement = "";
                    numberOfBlankReplacements++;

                    for (int z = 0; z < tokenized[i].Length; z++)
                    {
                        if (Char.IsLetter(tokenized[i][z]) != true)
                        {
                            blankReplacement += tokenized[i][z];
                        }
                        else
                        {
                            blankReplacement += "_";
                        }
                    }

                    stringReturnedAfterBlanks += blankReplacement + " ";
                    Debug.Log("The word " + tokenized[i] + " has a blank replacement equivalent of: " + blankReplacement);
                    randomNumber = rand.Next(1, randomChance);
                }
                else
                {
                    stringReturnedAfterBlanks += tokenized[i] + " ";
                    randomNumber = 1;
                    Debug.Log(tokenized[i] + " is either not 4 letters long or it doesn't have the right POS.");
                }
            }
            else
            {
                stringReturnedAfterBlanks += tokenized[i] + " ";
                randomNumber = rand.Next(1, randomChance);
            }
        }

        for (int size = 0; size < lengthOfText; size++)
        {
            m_returnedArray[0, size] = wordsBeingReplaced[size];
            m_returnedArray[1, size] = partsOfSpeechInBlanks[size];
        }

        for (int i = 0; i <numberOfBlankReplacements; i++)
        {
            Debug.Log(indexOfBlanks[i]);
        }

        m_returnedArray[2, 0] = stringReturnedAfterBlanks;
        Debug.Log("The first index in the first array is: " + m_returnedArray[0, 0] + "\n\n\n\n\n\n\n .");
        Debug.Log(m_returnedArray[0, 0] + " is a(n) " + m_returnedArray[1, 0]);
        Debug.Log("The string returned from the array is: " + m_returnedArray[2, 0]);
        return m_returnedArray;
    }
}
