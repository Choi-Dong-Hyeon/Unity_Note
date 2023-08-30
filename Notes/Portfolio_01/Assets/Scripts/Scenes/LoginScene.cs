
public class LoginScene : BaseScene
{

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.LoginScene;
        Managers.Instance.Data.Init();
    }

    public override void Clear()
    {
        base.Clear();
    }
}
