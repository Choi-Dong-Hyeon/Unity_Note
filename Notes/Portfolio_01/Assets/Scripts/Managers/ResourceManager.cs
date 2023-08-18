using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        T original = Resources.Load<T>(path);
        return original;
    }


    public T Instantiate<T>(string path, Transform parent=null) where T : Object
    {
        T original = Load<T>($"Prefabs/{path}");

        T go = Object.Instantiate<T>(original, parent);

        go.name = original.name;

        return go;
    }


    public void Destroy<T>(T go) where T : Object
    {
        Object.Destroy(go);
    }



}
