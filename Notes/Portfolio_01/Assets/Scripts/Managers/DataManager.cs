using System.Collections.Generic;
using UnityEngine;


public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDictionary();
}


public class DataManager
{
    public Dictionary<int, Stat> StatDictionary { get; private set; } = new Dictionary<int, Stat>();

    public void Init()
    {
        StatDictionary = LoadJson<StatData, int, Stat>("StatData").MakeDictionary();
    }

    T LoadJson<T, Key, Value>(string path) where T : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Instance.Resource.Load<TextAsset>($"Data/{path}");
        T data = JsonUtility.FromJson<T>(textAsset.text);
        return data;
    }
}  