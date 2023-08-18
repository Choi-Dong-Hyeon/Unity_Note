using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction;

    public void OnUpdateKey()
    {
        if (KeyAction != null)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
                if (Input.GetMouseButtonDown(0)) KeyAction.Invoke();
            
        }
    }

}
