
public class UI_Popup : UI_Base
{
    protected override void Init()
    {
        Managers.Instance.UI.PopupSetCanvas(gameObject);
    }
}
