using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene type)
    {
        Managers.Instance.Clear();
        SceneManager.LoadScene(Enum.GetName(typeof(Define.Scene), type));
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }

}