using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action<Define.MouseEvent> MouseAction;
    bool _press = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _press = true;
            }
            else
            {
                if (_press)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _press = false;
            }
        }
    }
}
