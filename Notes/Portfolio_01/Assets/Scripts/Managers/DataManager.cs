using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDictionary();
}

public class DataManager
{
    public T LoadJson<T, Key, Value>(string path) where T : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Instance.Resource.Load<TextAsset>($"Data/{path}");
        T data = JsonUtility.FromJson<T>(textAsset.text);
        return data;
    }


    public void Save()
    {
        string path = Application.persistentDataPath + "/";
        string fileName = "";
        BaseStat asd = new BaseStat();
        string data = JsonUtility.ToJson(asd);
        File.WriteAllText(path + fileName, data);
    }

    public void Load()
    {

    }

}




