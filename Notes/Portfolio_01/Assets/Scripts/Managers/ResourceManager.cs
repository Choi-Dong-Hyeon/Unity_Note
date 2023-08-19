using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{

    Dictionary<string, Object> _dictionary = new Dictionary<string, Object>();

    public T Load<T>(string path) where T : Object
    {
        T original = Resources.Load<T>(path);

        if (_dictionary.ContainsKey(original.name))
        {
            return _dictionary[original.name] as T;
        }
        else
        {
            _dictionary.Add(original.name, original);
        }

        return original;
    }


    public T Instantiate<T>(string path, Transform parent = null) where T : Object
    {
        T original = Load<T>($"Prefabs/{path}");

        T go = Object.Instantiate<T>(original, parent);

        go.name = original.name;

        if (_dictionary.ContainsKey(go.name))
        {
            return _dictionary[go.name] as T;
        }

        return go;
    }


    public void Destroy<T>(T go) where T : Object
    {
        Object.Destroy(go);
    }

}
