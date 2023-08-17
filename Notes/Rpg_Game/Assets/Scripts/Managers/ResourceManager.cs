using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public T Instantiate<T>(string path, Transform trans = null) where T : Object
    {
        T go = Load<T>($"Prefabs/{path}");

        return Object.Instantiate(go,trans);
    }


}
