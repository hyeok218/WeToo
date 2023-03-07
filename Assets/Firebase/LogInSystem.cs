using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInSystem : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;

    public InputField email;
    public InputField password;

    public Text outputText;



    // Start is called before the first frame update
    void Start()
    {
        //canvas2.SetActive(false);
        FirebaseAuthManager.Instance.LoginState += OnChangedState;
        FirebaseAuthManager.Instance.Init();
    }

    private void OnChangedState(bool sign)
    {
        outputText.text = sign ? "로그인 : " : "접속 상태";
        outputText.text += FirebaseAuthManager.Instance.UserId;
        //canvas.SetActive(false);
        //canvas2.SetActive(true);
    }

    

    public void Create()
    {
        string e = email.text;
        string p = password.text;

        FirebaseAuthManager.Instance.Create(e, p);
    }

    public void LogIn()
    {
        FirebaseAuthManager.Instance.LogIn(email.text, password.text);
       
    }

    public void LogOut()
    {
        FirebaseAuthManager.Instance.LogOut();
   
    }

    public void Connect()
    {
        FirebaseAuthManager.Instance.Connect();

    }
}
