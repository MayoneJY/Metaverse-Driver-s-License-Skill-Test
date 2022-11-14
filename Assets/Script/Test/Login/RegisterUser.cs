using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField ConfirmPasswordInput;
    public Button SubmitButton;
    // Start is called before the first frame update
    void Start()
    {
        SubmitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Server.RegisterUser(UsernameInput.text, PasswordInput.text, ConfirmPasswordInput.text));
        });
    }
}
