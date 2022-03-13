using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SharpNL;
using SharpNL.Tokenize;
using SharpNL.POSTag;
using System.IO;
using SharpNL.Utility;

public class displayParsedText : MonoBehaviour
{
    private Text thisDisplay;
    static string textToParse = "Hi this is really cool and I am happy that I can be here.";
    static WhitespaceTokenizer whitespaceTokenizer = WhitespaceTokenizer.Instance;
    private static FileStream fileToOpen = new FileStream(@"C:\Code\OpenNLP_Models\en-pos-maxent.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
    static POSModel model = new POSModel(fileToOpen);
    static POSTaggerME tagger = new POSTaggerME(model);
    static string[] tokenized = whitespaceTokenizer.Tokenize(textToParse);
    string[] tags = tagger.Tag(tokenized);
    static string textToDisplay = "";

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tags.Length; i++)
        {
            textToDisplay += tags[i] + " ";
        }

        thisDisplay = GameObject.Find("Text").GetComponent<Text>();
        thisDisplay.text = textToDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
