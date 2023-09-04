
public class GameScene : BaseScene
{

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.GameScene;

        CursorController cursor = GetComponent<CursorController>();
        if (cursor == null)
        {
            gameObject.AddComponent<CursorController>();
        }

    }

    public override void Clear()
    {
        base.Clear();
    }


}
