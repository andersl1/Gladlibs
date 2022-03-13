using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayAnimScript : MonoBehaviour
{
    public Animator flipping_ANIM;
    private bool nounTrue;
    private bool adjectiveTrue;
    private bool adverbTrue;
    
    public void ResetLoop()
    {
        flipping_ANIM.SetBool("NounEmpty", false);
        flipping_ANIM.SetBool("AdjectiveEmpty", false);
        flipping_ANIM.SetBool("AdverbEmpty", false);
        flipping_ANIM.SetBool("ProperNounEmpty", false);
        flipping_ANIM.SetBool("PluralNounEmpty", false);
        flipping_ANIM.SetBool("PresentTenseVerbEmpty", false);
        flipping_ANIM.SetBool("PastTenseVerbEmpty", false);
        flipping_ANIM.SetBool("AdverbEndingInLyEmpty", false);
    }

    public void PlayAnimNoun()
    {
        flipping_ANIM.SetTrigger("FlipAnim");
        if (flipping_ANIM.GetInteger("NumPOS") == 1)
        {
            flipping_ANIM.SetBool("NounEmpty", true);
        }
        else
        {
            flipping_ANIM.SetInteger("NumPOS", 1);
        }

        Debug.Log("A was pressed!");
    }
    
    public void PlayAnimAdjective()
    {
        flipping_ANIM.SetTrigger("FlipAnim");
        if (flipping_ANIM.GetInteger("NumPOS") == 2)
        {
            flipping_ANIM.SetBool("AdjectiveEmpty", true);
        }
        else
        {
            flipping_ANIM.SetInteger("NumPOS", 2);
        }

        Debug.Log("B was pressed!");
    }

    public void PlayAnimAdverb()
    {
        flipping_ANIM.SetTrigger("FlipAnim");
        if (flipping_ANIM.GetInteger("NumPOS") == 3)
        {
            flipping_ANIM.SetBool("AdverbEmpty", true);
        }
        else
        {
            flipping_ANIM.SetInteger("NumPOS", 3);
        }

        Debug.Log("B was pressed!");
    }

    public void PlayAnimProperNoun()
    {
        flipping_ANIM.SetTrigger("FlipAnim");
        if (flipping_ANIM.GetInteger("NumPOS") == 4)
        {
            flipping_ANIM.SetBool("ProperNounEmpty", true);
        }
        else
        {
            flipping_ANIM.SetInteger("NumPOS", 4);
        }

        Debug.Log("B was pressed!");
    }

    public void PlayAnimPluralNoun()
    {
        flipping_ANIM.SetTrigger("FlipAnim");
        if (flipping_ANIM.GetInteger("NumPOS") == 5)
        {
            flipping_ANIM.SetBool("PluralNounEmpty", true);
        }
        else
        {
            flipping_ANIM.SetInteger("NumPOS", 5);
        }

        Debug.Log("B was pressed!");
    }

    public void PlayAnimPresentTenseVerb()
    {
        flipping_ANIM.SetTrigger("FlipAnim");
        if (flipping_ANIM.GetInteger("NumPOS") == 6)
        {
            flipping_ANIM.SetBool("PresentTenseVerbEmpty", true);
        }
        else
        {
            flipping_ANIM.SetInteger("NumPOS", 6);
        }

        Debug.Log("B was pressed!");
    }

    public void PlayAnimPastTenseVerb()
    {
        flipping_ANIM.SetTrigger("FlipAnim");
        if (flipping_ANIM.GetInteger("NumPOS") == 7)
        {
            flipping_ANIM.SetBool("PastTenseVerbEmpty", true);
        }
        else
        {
            flipping_ANIM.SetInteger("NumPOS", 7);
        }

        Debug.Log("B was pressed!");
    }

    public void PlayAnimAdverbEndingInLy()
    {
        flipping_ANIM.SetTrigger("FlipAnim");
        if (flipping_ANIM.GetInteger("NumPOS") == 8)
        {
            flipping_ANIM.SetBool("AdverbEndingInLyEmpty", true);
        }
        else
        {
            flipping_ANIM.SetInteger("NumPOS", 8);
        }

        Debug.Log("B was pressed!");
    }

    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}   

