using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using System;
using UnityEngine.SceneManagement;

public class FirebaseAuthManager
{

    public int cnt = 0;
    //싱글톤
    private static FirebaseAuthManager instance = null;

    public static FirebaseAuthManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FirebaseAuthManager();
            }

            return instance;
        }
    }
    private FirebaseAuth auth; // 로그인 / 회원가입 등에 사용
    private FirebaseUser user; // 인증이 완료된 유저 정보

    public string UserId => user.UserId;


    

    public void Create(string email,string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                //회원가입 실패 이유 => 이메일이 비정상 / 비밀번호가 너무 간단 / 중복된 이메일 등등..
                Debug.LogError("회원가입 실패");
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogError("회원가입 완료");
        });
    }

    public Action<bool> LoginState;

    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;
        //임시처리
        if (auth.CurrentUser != null)
        {
            LogOut();
        }
        auth.StateChanged += Onchanged;  //계정이 바뀔때마다 호출이되는 함수
    }

    private void Onchanged(object sender, EventArgs e)
    {
        if (auth.CurrentUser != user) //계정상태가 변하면
        {
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if (!signed && user != null)
            {
                Debug.Log("로그아웃");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if(signed)
            {
                Debug.Log("로그인");
                LoginState?.Invoke(true);
                

            }
        }
    }

    public void LogIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("로그인 취소");
                return;
            }
            if (task.IsFaulted)
            {
                //회원가입 실패 이유 => 이메일이 비정상 / 비밀번호가 너무 간단 / 중복된 이메일 등등..
                Debug.LogError("로그인 실패");
                return;
            }
            if (task.IsCompleted)
            {   
                FirebaseUser newUser = task.Result;
                Debug.LogError("로그인 완료");
                Debug.LogError(UserId);
                cnt = 1;
            }

            
        });
    }

    public void Connect()
    {
        Debug.Log("접속");
        SceneManager.LoadScene(1);
        cnt = 1;
    }

    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("로그아웃");
        cnt = 0;
    }
}
