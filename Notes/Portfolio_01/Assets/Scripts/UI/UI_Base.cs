using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];

        for (int i = 0; i < names.Length; i++)
        {
            foreach (T component in GetComponentsInChildren<T>())
            {
                if (component.name == names[i])
                    objects[i] = component;
            }
        }
        _objects.Add(typeof(T), objects);
    }


    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        _objects.TryGetValue(typeof(T), out UnityEngine.Object[] objects);

        return objects[idx] as T;
    }

    private void Awake()
    {
        Init();
    }
    protected virtual void Init() { }


}
