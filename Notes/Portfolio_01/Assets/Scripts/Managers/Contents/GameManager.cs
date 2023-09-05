using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public Dictionary<int, GameObject> _players { get; private set; } = new();
    public Dictionary<int, GameObject> _monsters { get; private set; } = new Dictionary<int, GameObject>();

    public GameObject Spawn(Define.WorldObjects type, string path, Transform parent = null)
    {
        GameObject go = null;

        switch (type)
        {
            case Define.WorldObjects.Monster:
                go = Managers.Instance.Resource.Instantiate<GameObject>($"Monsters/{path}", parent);
                _monsters.Add((int)Define.WorldObjects.Monster, go);
                break;
            case Define.WorldObjects.Player:
                go = Managers.Instance.Resource.Instantiate<GameObject>($"Players/{path}", parent);
                _players.Add((int)Define.WorldObjects.Player, go);
                break;
        }
        return go;
    }

    public void Despawn(GameObject go)
    {
        Define.WorldObjects type = go.GetComponent<BaseController>()._worldObject;

        switch (type)
        {
            case Define.WorldObjects.Monster:
                if (_monsters.ContainsKey((int)type))
                {
                    _monsters.Remove((int)Define.WorldObjects.Monster);
                }
                break;
            case Define.WorldObjects.Player:
                if (_players[(int)type] == go)
                {
                    _players[(int)type] = null;
                }
                break;
        }    
        Managers.Instance.Resource.Destroy(go);
    }

    public Define.WorldObjects GetWorldObjectType(GameObject go)
    {
        BaseController baseController = go.GetComponent<BaseController>();
        return baseController._worldObject;
    }
}
