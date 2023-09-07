using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public GameObject _players;
    public HashSet<GameObject> _monsters = new HashSet<GameObject>();

    public Action<int> OnSpawnEvent;

    public GameObject Spawn(Define.WorldObjects type, string path, Transform parent = null)
    {
        GameObject go = Managers.Instance.Resource.Instantiate<GameObject>($"{path}", parent);
        
        switch (type)
        {
            case Define.WorldObjects.Monster:
                _monsters.Add(go);
                if (OnSpawnEvent != null)
                    OnSpawnEvent.Invoke(1);
                break;
            case Define.WorldObjects.Player:
                _players = go;
                break;
        }
        return go;
    }

    public void Despawn(GameObject go)
    {
        Define.WorldObjects type = GetWorldObjectType(go);

        switch (type)
        {
            case Define.WorldObjects.Monster:
                //if (_monsters.Contains(go))
                {
                 //   _monsters.Remove(go);
                    if (OnSpawnEvent != null)
                    {
                        Debug.Log("-1");
                        OnSpawnEvent.Invoke(-1);
                    }
                }
                break;
            case Define.WorldObjects.Player:
                if (_players == go)
                {
                    _players = null;
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
