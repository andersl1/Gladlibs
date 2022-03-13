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
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
//using FrostweepGames.Plugins.Core;
using Google.Cloud.Language.V1;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using static Google.Cloud.Language.V1.AnnotateTextRequest.Types;
//using FrostweepGames.Plugins.GoogleCloud.NaturalLanguage;*/
using Google.Apis.Services;
public class ShowTheMadlib : MonoBehaviour
{
    // The objects within the scene to display
    public Text loadingScreenText;
    public Camera backGround;

    private bool completed;
    public float currentAmountOfTime = 2f;
    private string[] words;
    private static string[] text = null;
    private string[,] m_returnedArray = null;
    private static string[,] m_displayedArray = null;
    private static string m_textToString = "";
    private static int m_lengthOfFirstIndex;

    // Initialize the variables for the Arrays that are going to be returned
    private static string[] wordsBeingReplaced = null;
    private static string stringReturnedAfterBlanks;
    private static string typeOfPOS;
    private static string[] partsOfSpeechInBlanks = null;
    private static int randomNumber;
    private static int numberPrompts = 0;
    private static int blankCreationNumber = 1;
    private static System.Random rand = new System.Random();
    private static int listIndex = 0;
    private static string blankReplacement;
    private static int[] indexOfBlanks = null;
    private static List<string> blankFollowingItems = new List<string> { "'s", "'t", "'ve", "'d", "'re", "“", "?", ".", ":", "\"", "”", "...", ";", ")", ",", "!" };

    // Initialize the tagger and tokenizer to get the POS of the words
    static WhitespaceTokenizer whitespaceTokenizer = WhitespaceTokenizer.Instance;
    private static FileStream fileToOpen;
    static POSModel model;
    static POSTaggerME tagger; 
    static string[] tokenized;
    static string[] tags = null;
    
    // Start is called before the first frame update
    // Test if the user is logged in and set completed to false. 
    private void Awake()
    {
        if (DataManager.LoggedIn)
        {
            backGround.backgroundColor = DataManager.backGroundColor;
            completed = false;
            GenerateLib();
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }

    private void Update()
    {
        // Show a loading button and have it say different messages depending on the time
        if (currentAmountOfTime > 0)
        {
            currentAmountOfTime -= Time.deltaTime;
        }
        else
        {
            currentAmountOfTime = 2f;
            return;
        }

        if (currentAmountOfTime > 0 && currentAmountOfTime  <= 0.4)
        {
            loadingScreenText.text = "Loading.";
        }
        else if (currentAmountOfTime > 0.8 && currentAmountOfTime <= 1.2)
        {
            loadingScreenText.text = "Loading..";
        }
        else if (currentAmountOfTime > 1.2 && currentAmountOfTime <= 1.6)
        {
            loadingScreenText.text = "Loading...";
        }
        else
        {
            loadingScreenText.text = "Loading...";
        }

        // If the computation is done, load the next scene.
        if (completed)
        {
            OnClick();
        }
    }

    // Load the next scene
    public void OnClick()
    {
        SceneManager.LoadScene(5);
    }

    // Generate the madlib from the string that they've given.
    private void GenerateLib()
    {
        numberPrompts = 0;
        m_displayedArray = null;
        m_lengthOfFirstIndex = 0;
        m_textToString = null;
        m_displayedArray = null;

        // Get the length of the text so that it is passed to the generator: it needs the length to determine when it has reached the end.
        m_lengthOfFirstIndex = DataManager.lastLib.Length;

        // This array has three indices: parts of speech that are replaced, words that are replaced, and the text that is returned with blanks in it. 
        m_displayedArray = new string[3, m_lengthOfFirstIndex];
        
        // Store this is DataManager so that other scenes can use this information. 
        m_textToString = DataManager.lastLib;

        // Generate the blanks
        m_displayedArray = randomBlankGenerator(m_textToString, m_lengthOfFirstIndex);
        DataManager.lastLibWithBlanks = m_displayedArray[2, 0];

        // Get the number of blanks created to know how many prompts the user will be given for parts of speech.
        for (int z = 0; z < m_lengthOfFirstIndex; z++)
        {
            if (m_displayedArray[2, 0][z].ToString() == " ")
            {
                if (m_displayedArray[2, 0][z + 1].ToString() == "_")
                {
                    numberPrompts++;
                    z++;
                    continue;
                }
            }
        }

        // Store this in DataManager so that other scenes have access to this information.
        DataManager.lastLibBlankIndicies = new int[numberPrompts];
        DataManager.lastLibPOS = new string[numberPrompts];

        for (int i = 0; i < numberPrompts; i++)
        {
            DataManager.lastLibBlankIndicies[i] = int.Parse(m_displayedArray[3, i]);
            DataManager.lastLibPOS[i] = m_displayedArray[1, i];
        }

        // Completion: go to the next screen.
        completed = true;
    }

    string[,] randomBlankGenerator(string textToGenerate, int lengthOfText)
    {
        // Random chance is set to 1 in 6 for chances of a blank being created at any position.
        // These three arrays are initialized so that we can store the information in them later. 
        partsOfSpeechInBlanks = new string[lengthOfText];
        wordsBeingReplaced = new string[lengthOfText];
        m_returnedArray = new string[4, lengthOfText];

        // Index of the blanks created
        indexOfBlanks = new int[lengthOfText];
        int randomChance = 6;
        randomNumber = rand.Next(1, randomChance);

        // The string that is returned after the blanks are created. 
        stringReturnedAfterBlanks = "";

        string path = Application.dataPath + "/StreamingAssets/MyFirstProject-e5cd5136901c.json";

        LanguageServiceClientBuilder builder = new LanguageServiceClientBuilder
        {
            CredentialsPath = path
        };

        LanguageServiceClient client = builder.Build();

        //var credential = GoogleCredential.FromFile(path).CreateScoped(LanguageServiceClient.DefaultScopes);
        //credential.CreateWithUser("");

        //SceneManager.LoadScene(0);

       //var channel = new Grpc.Core.Channel(LanguageServiceClient.DefaultEndpoint.ToString(), credential);
        //StorageClient storage = StorageClient.Create(credential);

        Google.Cloud.Language.V1.Document document = new Google.Cloud.Language.V1.Document();
        document.Content = DataManager.lastLib;
        document.Type = Document.Types.Type.PlainText;
        document.Language = "EN-US";

        //LanguageServiceClient client = LanguageServiceClient.Create();

        AnnotateTextRequest.Types.Features features = new AnnotateTextRequest.Types.Features();

        features.ExtractSyntax = true;

        AnnotateTextResponse response = client.AnnotateText(document, features);

        var tokens = response.Tokens;

        int location = 0;
        int numTags = tokens.Count;
        tags = new string[numTags];
        words = new string[numTags];

        foreach (var token in tokens)
        {
            if (token.PartOfSpeech.Tense.ToString() == "Past" || token.PartOfSpeech.Proper.ToString() == "Proper")
            {
                tags[location] = token.PartOfSpeech.Tag.ToString() + "ed";
            }
            else if (token.PartOfSpeech.Number.ToString() == "Plural")
            {
                tags[location] = token.PartOfSpeech.Tag.ToString() + "s";
            }
            else
            {
                tags[location] = token.PartOfSpeech.Tag.ToString();
            }

            words[location] = token.Text.Content;
            location += 1;
        }

        int numberOfBlankReplacements = 0;
        string currentTag;

        // For all of the words in the text. 
        for (int i = 0; i < numTags; i++)
        {
            if (listIndex < (numTags))
            {
                listIndex++;
            }

            // If the random number generates a 'blank creation number.'
            if (randomNumber == blankCreationNumber)
            {
                currentTag = tags[i];

                // Turn the tag into a readable string. If not a desired tag (like coordinating cunjunction or 'CC'), set the type to NONE

                switch (currentTag)
                {
                    case "Noun":
                        typeOfPOS = "noun";
                        break;
                    case "Verb":
                        typeOfPOS = "present tense verb";
                        break;
                    case "Verbed":
                        typeOfPOS = "past tense verb";
                        break;
                    case "Nouned":
                        typeOfPOS = "proper noun";
                        break;
                    case "Nouns":
                        typeOfPOS = "plural noun";
                        break;
                    case "Adv":
                        typeOfPOS = "adverb ending in 'ly'";
                        break;
                    case "Adj":
                        typeOfPOS = "adjective";
                        break;
                    case "Det":
                        typeOfPOS = "determiner";
                        break;
                    default:
                        typeOfPOS = "None";
                        break;
                }

                // If it is a good type and the length of the word is greater than 4, create a blank and put the contents of the word and it's index into the arrays. 
                if (typeOfPOS != "None" && words[i].Length > 4 && typeOfPOS != "determiner")
                {
                    wordsBeingReplaced[numberOfBlankReplacements] = words[i];
                    partsOfSpeechInBlanks[numberOfBlankReplacements] = typeOfPOS;
                    indexOfBlanks[numberOfBlankReplacements] = i;

                    // This will sustitute the word at this index for a blank.
                    blankReplacement = "";
                    numberOfBlankReplacements++;

                    for (int z = 0; z < words[i].Length; z++)
                    {
                        if (Char.IsLetter(words[i][z]) != true)
                        {
                            blankReplacement += words[i][z];
                        }
                        else
                        {
                            blankReplacement += "_";
                        }
                    }

                    stringReturnedAfterBlanks += blankReplacement + " ";
                    randomNumber = rand.Next(1, randomChance);
                }
                else
                {
                    // If this word was determined to be a blank, but does not meet the requirements, set the number to 1 so that it tests the next word in the string. 
                    // And put the original word back into the string. 

                    stringReturnedAfterBlanks += words[i] + " ";
                    randomNumber = 1;
                }
            }
            else
            {
                // Otherwise, add the word that was originally in the string as well as a blank and generate a new random number.

                stringReturnedAfterBlanks += words[i] + " ";
                randomNumber = rand.Next(1, randomChance);
            }
        }

        if (numberOfBlankReplacements < 1)
        {
            Debug.Log("The number of blanks is: " + numberOfBlankReplacements + ", which caused an error.");
            SceneManager.LoadScene(2);
        }

        // Place all of this information into the array!
        for (int size = 0; size < lengthOfText; size++)
        {
            m_returnedArray[0, size] = wordsBeingReplaced[size];
            m_returnedArray[1, size] = partsOfSpeechInBlanks[size];
        }

        for (int i = 0; i < numberOfBlankReplacements; i++)
        {
            m_returnedArray[3, i] = indexOfBlanks[i].ToString();
        }

        m_returnedArray[2, 0] = stringReturnedAfterBlanks;
        return m_returnedArray;
    }
}
