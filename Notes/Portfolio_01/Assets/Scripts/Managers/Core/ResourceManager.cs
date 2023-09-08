using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    Dictionary<string, Object> _dictionary = new Dictionary<string, Object>();

    public T Load<T>(string path) where T : Object
    {
        T original = Resources.Load<T>(path);
        return original;
    }

    public T Instantiate<T>(string path, Transform parent = null) where T : Object
    {
        T original = Load<T>($"Prefabs/{path}");
        if (original == null) return null;
        T go = Object.Instantiate<T>(original, parent);

        go.name = original.name;

        //if (_dictionary.ContainsKey(go.name))
        //{
        //    return _dictionary[go.name] as T;
        //}
        //else
        //{
        //    _dictionary.Add(go.name, go);
        //}
        // 객체생성시 하나로 관리되어 좌표설정시 모든 객체의 위치가 변경되는 문제점 이 있음

        return go;
    }

    public void Destroy(GameObject go)
    {
        Object.Destroy(go.gameObject);
    }
}
