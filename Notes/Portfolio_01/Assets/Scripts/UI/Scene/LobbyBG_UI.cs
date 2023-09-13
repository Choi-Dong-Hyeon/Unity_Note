using UnityEngine;
using UnityEngine.UI;

public class LobbyBG_UI : UI_Scene
{
    enum Texts
    {
        EmailText,
    }

    protected override void Init()
    {
        base.Init();
        Canvas canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
        Bind<Text>(typeof(Texts));
        Get<Text>((int)Texts.EmailText).text =Managers.Instance.Auth._user.Email+ "님 환영합니다.";
    }
}
