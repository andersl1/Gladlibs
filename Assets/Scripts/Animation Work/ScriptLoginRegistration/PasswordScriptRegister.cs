using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PasswordScriptRegister : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public RegisterScript register;
    public InputField password;
    public InputField passwordAgain;

    public void OnSelect(BaseEventData eventData)
    {
        register.PlayAnimationPassword();
    }

    public void OnDeselect(BaseEventData data)
    {
        register.PlayNeitherAnimation();
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
            if (password.isActiveAndEnabled)
            {
                passwordAgain.ActivateInputField();
            }
        }
    }
}