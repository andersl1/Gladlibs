using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UsernameScriptLogin : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public LoginScript login;
    public InputField password;
    public InputField username;

    public void OnSelect(BaseEventData eventData)
    {
        login.PlayAnimationUsername();
    }

    public void OnDeselect(BaseEventData data)
    {
        login.PlayNeitherAnimation();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.isActiveAndEnabled)
            {
                password.ActivateInputField();
            }
        }
    }
}
