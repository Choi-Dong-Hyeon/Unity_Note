public class LoginScene : BaseScene
{
    public override void Clear()
    {
        
    }

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.Login;
    }

    void Start()
    {
        Init();
        Managers.Scene.LoadScene(Define.Scene.InGame);
    }

}
