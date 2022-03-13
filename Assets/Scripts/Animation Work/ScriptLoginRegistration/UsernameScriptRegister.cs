using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UsernameScriptRegister : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public RegisterScript register;
    public InputField username;
    public InputField password;

    public void OnSelect(BaseEventData eventData)
    {
        register.PlayAnimationUsername();
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
        if (username.isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                password.ActivateInputField();
            }
        }
    }
}