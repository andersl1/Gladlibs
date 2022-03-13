using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextGivenByPlayer : MonoBehaviour
{
    private TMP_InputField madlibToGenerate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            madlibToGenerate = this.GetComponent<TMP_InputField>();
            Debug.Log(madlibToGenerate.text);
        }
    }
}
