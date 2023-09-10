using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;

public class Login_UI : UI_Popup
{
    enum InputFields
    {
        EmailField,
        PasswordField,
    }

    enum Buttons
    {
        LoginButton,
        CreateButton,
    }

    FirebaseAuth _auth;
    FirebaseUser _user;
    bool _isvelied;

    protected override void Init()
    {
        base.Init();
        _auth = FirebaseAuth.DefaultInstance;

        Bind<InputField>(typeof(InputFields));
        Bind<Button>(typeof(Buttons));

        InputField email = Get<InputField>((int)InputFields.EmailField);
        InputField password = Get<InputField>((int)InputFields.PasswordField);

        Button loginButton = Get<Button>((int)Buttons.LoginButton);
        loginButton.onClick.AddListener(() => { Login(email.text, password.text); });

        Button createButton = Get<Button>((int)Buttons.CreateButton);
        createButton.onClick.AddListener(() => { Create(email.text, password.text); });
    }

    void Update()
    {
        if (_isvelied)
        {
            Managers.Instance.Scene.LoadScene(Define.Scene.GameScene);
        }
    }

    void Create(string email, string password)
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

    void Login(string email, string password)
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

    void LogOut()
    {
        _auth.SignOut();
    }


}
