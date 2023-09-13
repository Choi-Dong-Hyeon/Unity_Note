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
                Debug.Log("ȸ������ ����");
                return;
            }

            if (task.IsCanceled)
            {
                Debug.Log("ȸ������");
                return;
            }

            FirebaseUser newUser = task.Result.User;
            Debug.Log("ȸ������ ����");

        });
    }

    public void Login(string email, string password)
    {
        _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("�α��� ����");
                return;
            }

            if (task.IsCanceled)
            {
                Debug.Log("�α���ĵ��");
                return;
            }

            Debug.Log("�α��� ����");

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
