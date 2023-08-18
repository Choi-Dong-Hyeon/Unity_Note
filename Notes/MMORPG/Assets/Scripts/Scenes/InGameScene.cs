using System.Collections.Generic;
using System.Data;

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
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        gameObject.AddComponent<CursorController>();
    }

    public override void Clear()
    {

    }

}
