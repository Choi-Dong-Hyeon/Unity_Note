using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    enum Buttons
    {
        PointButton,
        PointText,
    }


    void Start()
    {

        Bind<Text>(typeof(Buttons));

        Get<Text>((int)Buttons.PointText).text = "asdasd";
    }


    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];

        for (int i = 0; i < names.Length; i++)
        {
            foreach (T component in GetComponentsInChildren<T>())
            {
                if (component.name == names[i])
                {
                    objects[i] = component;
                }
            }
        }
        _objects.Add(typeof(T), objects);

    }


    T FindChild<T>(GameObject go, string names) where T : UnityEngine.Object
    {
        foreach (T component in go.GetComponentsInChildren<T>())
        {
            if (component.name == names)
                return component;
        }
        return null;
    }



    T Get<T>(int idx) where T : UnityEngine.Object
    {
        _objects.TryGetValue(typeof(T), out UnityEngine.Object[] objects);

        return objects[idx] as T;
    }



}
