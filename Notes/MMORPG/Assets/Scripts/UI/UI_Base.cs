using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> objects = new Dictionary<Type, UnityEngine.Object[]>();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] _objects = new UnityEngine.Object[names.Length];
        for (int i = 0; i < names.Length; i++)
        {
            _objects[i] = FindChild<T>(gameObject, names[i]);
        }
        objects.Add(typeof(T), _objects);
    }

    protected T FindChild<T>(GameObject go, string name) where T : UnityEngine.Object
    {
        foreach (T component in go.GetComponentsInChildren<T>())
        {
            if (component.name == name)
            {
                return component;
            }
        }
        return null;
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] obj;
        objects.TryGetValue(typeof(T), out obj);
        return obj[idx] as T;
    }

}
