using System.Collections.Generic;

public class InGameScene : BaseScene
{
    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.InGame;
        Dictionary<int, Stat> dict = Managers.Data.StatDict;
    }

    public override void Clear()
    {

    }

}
