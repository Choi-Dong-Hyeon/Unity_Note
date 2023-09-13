using UnityEngine;
using Firebase.Auth;

public class FireBaseAuthManager 
{
    FirebaseAuth _auth;
    public FirebaseUser _user;
    public bool _isvelied;

    public void SetAuth(FirebaseAuth auth) { _auth = auth; }


    public void Create(string email, string password)
    {
        _auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("회원가입 실패");
                return;
            }

            if (task.IsCanceled)
            {
                Debug.Log("회원가입");
                return;
            }

            FirebaseUser newUser = task.Result.User;
            Debug.Log("회원가입 성공");

        });
    }

    public void Login(string email, string password)
    {
        _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("로그인 실패");
                return;
            }

            if (task.IsCanceled)
            {
                Debug.Log("로그인캔슬");
                return;
            }

            Debug.Log("로그인 성공");

            if (task.IsCompleted)
            {
                _user = task.Result.User;
                _isvelied = true;
            }
        });
    }

    public void LogOut()
    {
        _auth.SignOut();
    }
}
