using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager instance;
    static Manager Instance { get { Init(); return instance; } }

    InputManager input = new InputManager();
    public static InputManager Input { get { return Instance.input; } }

   



    public static void Init()
    {
        GameObject go = GameObject.Find("@Manager");
        if (go == null)
        {
            go = new GameObject { name = "@Manager" };
            go.AddComponent<Manager>();
        }
        DontDestroyOnLoad(go);
        instance = go.GetComponent<Manager>();
    }

    void Start()
    {

    }


    void Update()
    {
        input.OnMoving();
    }
}
