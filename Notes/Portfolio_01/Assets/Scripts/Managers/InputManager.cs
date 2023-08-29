using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action OnMouseAction;

    public void UpdateMouse()
    {
        if (OnMouseAction != null)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            if (Input.GetMouseButtonDown(0))
            {
                OnMouseAction.Invoke();
            }
        }
    }

    public void Clear()
    {
        OnMouseAction = null;
    }

}
