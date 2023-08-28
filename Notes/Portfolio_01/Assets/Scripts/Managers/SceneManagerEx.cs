using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{

    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene type)
    {
        CurrentScene.Clear();
        SceneManager.LoadScene(Enum.GetName(typeof(Define.Scene), type));
    }



}