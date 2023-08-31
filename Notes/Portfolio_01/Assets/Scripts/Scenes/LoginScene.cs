
using System.Collections.Generic;

public class LoginScene : BaseScene
{

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.LoginScene;
        StatData s = Managers.Instance.Data.LoadJson<StatData, int, Stat>("StatData");
    }

    public override void Clear()
    {
        base.Clear();
    }
}
