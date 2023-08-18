using System;

public class InputManager
{

    public Action<Define.MouseEvent> OnMouseAction;

    public void UpdateMouse()
    {
        if (OnMouseAction != null)
        {
            OnMouseAction.Invoke(Define.MouseEvent.Click);
        }
    }
}
