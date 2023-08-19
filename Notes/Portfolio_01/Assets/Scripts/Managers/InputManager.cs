using System;
using UnityEngine;

public class InputManager
{

    public Action OnMouseAction;

    public void UpdateMouse()
    {
        if (OnMouseAction != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseAction.Invoke();

            }
        }
    }
}
