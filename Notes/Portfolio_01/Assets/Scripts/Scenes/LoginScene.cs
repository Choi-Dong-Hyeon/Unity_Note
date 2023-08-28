
using UnityEngine;

public class LoginScene : BaseScene
{

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.LoginScene;
        Managers.Instance.Scene.LoadScene(Define.Scene.GameScene);
    }


    void Test()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Managers.Instance.Scene.LoadScene(Define.Scene.GameScene);
        }
    }

    public override void Clear()
    {
        base.Clear();
        Debug.Log("Asd");
    }
}
