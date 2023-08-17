using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    public Action OnMoveAction;

   public void OnMoving()
    {
        if (OnMoveAction != null)
        {
            OnMoveAction.Invoke();
        }
    }


}
