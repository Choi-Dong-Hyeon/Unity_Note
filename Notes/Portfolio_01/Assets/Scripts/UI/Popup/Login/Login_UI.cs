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

    protected override void Init()
    {
        base.Init();
        Managers.Instance.Auth.SetAuth(FirebaseAuth.DefaultInstance);

        Bind<InputField>(typeof(InputFields));
        Bind<Button>(typeof(Buttons));

        InputField email = Get<InputField>((int)InputFields.EmailField);
        InputField password = Get<InputField>((int)InputFields.PasswordField);

        Button loginButton = Get<Button>((int)Buttons.LoginButton);
        loginButton.onClick.AddListener(() => { Managers.Instance.Auth.Login(email.text, password.text); });

        Button createButton = Get<Button>((int)Buttons.CreateButton);
        createButton.onClick.AddListener(() => { Managers.Instance.Auth.Create(email.text, password.text); });
    }

    void Update()
    {
        if (Managers.Instance.Auth._isvelied)
        {
            Managers.Instance.Scene.LoadScene(Define.Scene.LobbyScene);
        }
    }
}
