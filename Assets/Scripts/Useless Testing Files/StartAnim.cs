using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    Animator anim;
    int hashOfTrigger = Animator.StringToHash("MakeBig");
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Got here");
            anim.SetTrigger(hashOfTrigger);
        }
    }
}
