using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing2 : MonoBehaviour
{
    // Since I could not figure out how to run animations, I just counted the time that the animation plays for and set the anim.enabled to false so that it wouldn't play
    // after that time.
    private int x = 0;
    public Animator anim;
    private float thisTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isAnimating", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (thisTime > 0)
        {
            anim.enabled = true;
            anim.Play("SecondFlipping");
            thisTime -= Time.deltaTime;
        }
        else
        {
            anim.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (thisTime > 0 != true)
            {
                thisTime = .38053f;
            }
        }
    }

    IEnumerator playAnim()
    {
        anim.enabled = true;
        anim.SetBool("isAnimating", true);
        yield return new WaitForSeconds(2f);
    }
}
