using UnityEngine;

public class ResourceManager
{

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }


    public GameObject Instantiate(string path, Transform parent=null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
      
        return Object.Instantiate(original, parent);
    }



    public void Destroy(GameObject go, float time = 0)
    {
        Object.Destroy(go, time);
    }

}
