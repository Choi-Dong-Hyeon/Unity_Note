
public class UI_Scene : UI_Base
{
    protected override void Init()
    {
        Managers.Instance.UI.SceneSetCanvas(gameObject);
    }
}
