using UnityEngine;

public class LoginScene : BaseScene
{

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.LoginScene;
        Managers.Instance.UI.ShowSceneUI<LoginBG_UI>("LoginBG_UI");
        Managers.Instance.UI.ShowPopupUI<Login_UI>("Login_UI");
    }

    public override void Clear()
    {
        base.Clear();
    }
}
