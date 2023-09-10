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

    void Login(string email, string password)
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

    void LogOut()
    {
        _auth.SignOut();
    }


}
