
using UnityEngine;

public class LoginScene : BaseScene
{

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.LoginScene;
        Managers.Instance.Sound.Play(Define.Sound.Effect, "univ0001");
        Managers.Instance.Sound.Play(Define.Sound.Effect, "univ0001");
        Managers.Instance.Sound.Play(Define.Sound.Effect, "univ0001");
        Managers.Instance.Sound.Play(Define.Sound.Effect, "univ0001");
    }

    public override void Clear()
    {
        base.Clear();
    }
}
