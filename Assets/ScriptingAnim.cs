using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptingAnim : MonoBehaviour
{
    public PlayAnimScript playAnim;
    public SpriteRenderer background;
    public float fadeTime = 1f;
    public float fadeToAmount = .2f;
    public float fadeSpeed = 0.001f;
    public float fadeIncrement = 0.02f;
    private Color backGroundColor;
    public void EnterReset()
    {
        playAnim.ResetLoop();
    }

    public void StartUp()
    {
        playAnim.flipping_ANIM.SetBool("Entering", true);
    }

    private void Start()
    {
        StartUp();
    }
    public void ResetColor()
    {
        if (playAnim.flipping_ANIM.GetInteger("NumPOS") == 1)
        {
            StartCoroutine(FadeToBlue());
        }
        else if (playAnim.flipping_ANIM.GetInteger("NumPOS") == 2)
        {
            StartCoroutine(FadeToRed());
        }
        else if (playAnim.flipping_ANIM.GetInteger("NumPOS") == 3)
        {
            StartCoroutine(FadeToGreen());
        }
        else if (playAnim.flipping_ANIM.GetInteger("NumPOS") == 4)
        {
            StartCoroutine(FadeToYellow());
        }
        else if (playAnim.flipping_ANIM.GetInteger("NumPOS") == 5)
        {
            StartCoroutine(FadeToPurple());
        }
        else if (playAnim.flipping_ANIM.GetInteger("NumPOS") == 6)
        {
            StartCoroutine(FadeToBrown());
        }
        else if (playAnim.flipping_ANIM.GetInteger("NumPOS") == 7)
        {
            StartCoroutine(FadeToOrange());
        }
        else if (playAnim.flipping_ANIM.GetInteger("NumPOS") == 8)
        {
            StartCoroutine(FadeToActualPurple());
        }
    }

    IEnumerator FadeToActualPurple()
    {
        for (float i = fadeTime; i > fadeToAmount; i -= fadeSpeed)
        {
            backGroundColor = background.color;

            if (backGroundColor.b > 0.5f)
            {
                backGroundColor.b -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.b < 0.46f)
                {
                    backGroundColor.b += fadeIncrement;
                }
            }

            if (backGroundColor.r < 0.3f)
            {
                backGroundColor.r += fadeIncrement;
            }
            else
            {
                if (backGroundColor.r > 0.34f)
                {
                    backGroundColor.r -= fadeIncrement;
                }
            }

            if (backGroundColor.g > 0.1f)
            {
                backGroundColor.g -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.g < 0.06f)
                {
                    backGroundColor.g += fadeIncrement;
                }
            }

            background.color = backGroundColor;

            yield return new WaitForSeconds(fadeSpeed / 2);
        }
    }

    IEnumerator FadeToOrange()
    {
        for (float i = fadeTime; i > fadeToAmount; i -= fadeSpeed)
        {
            backGroundColor = background.color;

            if (backGroundColor.b > 0.1f)
            {
                backGroundColor.b -= fadeIncrement;
            }

            if (backGroundColor.r < 1f)
            {
                backGroundColor.r += fadeIncrement;
            }

            if (backGroundColor.g > 0.5f)
            {
                backGroundColor.g -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.g < 0.46f)
                {
                    backGroundColor.g += fadeIncrement;
                }
            }

            background.color = backGroundColor;

            yield return new WaitForSeconds(fadeSpeed / 2);
        }
    }

    IEnumerator FadeToBrown()
    {
        for (float i = fadeTime; i > fadeToAmount; i -= fadeSpeed)
        {
            backGroundColor = background.color;

            if (backGroundColor.b > 0.1f)
            {
                backGroundColor.b -= fadeIncrement;
            }

            if (backGroundColor.r < 0.4f)
            {
                backGroundColor.r += fadeIncrement;
            }
            else
            {
                if (backGroundColor.r > 0.42f)
                {
                    backGroundColor.r -= fadeIncrement;
                }
            }

            if (backGroundColor.g > 0.2f)
            {
                backGroundColor.g -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.g < 0.16f)
                {
                    backGroundColor.g += fadeIncrement;
                }
            }

            background.color = backGroundColor;

            yield return new WaitForSeconds(fadeSpeed / 2);
        }
    }

    IEnumerator FadeToPurple()
    {
        for (float i = fadeTime; i > fadeToAmount; i -= fadeSpeed)
        {
            backGroundColor = background.color;

            if (backGroundColor.b < 1f)
            {
                backGroundColor.b += fadeIncrement;
            }

            if (backGroundColor.r < 1f)
            {
                backGroundColor.r += fadeIncrement;
            }

            if (backGroundColor.g > 0.5f)
            {
                backGroundColor.g -= fadeIncrement;
            }
            else 
            {
                if (backGroundColor.g > 0.5f)
                {
                    backGroundColor.g -= fadeIncrement;
                }
            }

            background.color = backGroundColor;

            yield return new WaitForSeconds(fadeSpeed / 2);
        }
    }

    IEnumerator FadeToYellow()
    {
        for (float i = fadeTime; i > fadeToAmount; i -= fadeSpeed)
        {
            backGroundColor = background.color;

            if (backGroundColor.b > 0.5f)
            {
                backGroundColor.b -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.b < 0.46f)
                {
                    backGroundColor.b += fadeIncrement;
                }
            }

            if (backGroundColor.r < 1f)
            {
                backGroundColor.r += fadeIncrement;
            }

            if (backGroundColor.g < 1f)
            {
                backGroundColor.g += fadeIncrement;
            }

            background.color = backGroundColor;

            yield return new WaitForSeconds(fadeSpeed / 2);
        }
    }

    IEnumerator FadeToGreen()
    {
        for (float i = fadeTime; i > fadeToAmount; i -= fadeSpeed)
        {
            backGroundColor = background.color;

            if (backGroundColor.b > 0.5f)
            {
                backGroundColor.b -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.b < 0.46f)
                {
                    backGroundColor.b += fadeIncrement;
                }
            }

            if (backGroundColor.r > 0.5f)
            {
                backGroundColor.r -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.r < 0.46f)
                {
                    backGroundColor.r += fadeIncrement;
                }
            }

            if (backGroundColor.g < 1f)
            {
                backGroundColor.g += fadeIncrement;
            }

            background.color = backGroundColor;

            yield return new WaitForSeconds(fadeSpeed / 2);
        }
    }

    IEnumerator FadeToRed()
    {
        for (float i = fadeTime; i > fadeToAmount; i -= fadeSpeed)
        {
            backGroundColor = background.color;

            if (backGroundColor.b > 0.5f)
            {
                backGroundColor.b -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.b < 0.46f)
                {
                    backGroundColor.b += fadeIncrement;
                }
            }

            if (backGroundColor.g > 0.5f)
            {
                backGroundColor.g -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.g < 0.46f)
                {
                    backGroundColor.g += fadeIncrement;
                }
            }
            
            if (backGroundColor.r < 1f)
            {
                backGroundColor.r += fadeIncrement;
            }
                 
            background.color = backGroundColor;

            yield return new WaitForSeconds(fadeSpeed / 2);
        }
    }

    IEnumerator FadeToBlue()
    {
        for (float i = fadeTime; i > fadeToAmount; i -= fadeSpeed)
        {
            backGroundColor = background.color;

            if (backGroundColor.r > 0.5f)
            {
                backGroundColor.r -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.r < 0.46f)
                {
                    backGroundColor.r += fadeIncrement;
                }
            }

            if (backGroundColor.g > 0.5f)
            {
                backGroundColor.g -= fadeIncrement;
            }
            else
            {
                if (backGroundColor.g < 0.46f)
                {
                    backGroundColor.g += fadeIncrement;
                }
            }

            if (backGroundColor.b < 1f)
            {
                backGroundColor.b += fadeIncrement;
            }

            background.color = backGroundColor;

            yield return new WaitForSeconds(fadeSpeed / 2);
        }
    }
}
