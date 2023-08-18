using System;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] _spawnPoint;
    public SpawnData[] spawnData;

    float _timer;
    int level;

    void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (!Managers.instance.isLive) return;

        _timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(Managers.instance._gameTime / 10f), spawnData.Length - 1);

        if (_timer > spawnData[level]._spawnTime)
        {
            _timer = 0f;
            Spawner();
        }
    }

    void Spawner()
    {
        GameObject enemy = Managers.instance.Pool.Get(0);
        enemy.transform.position = _spawnPoint[UnityEngine.Random.Range(1, _spawnPoint.Length)].position;
        enemy.GetComponent<MonsterController>().Init(spawnData[level]);

    }

}

[System.Serializable]
public class SpawnData
{
    public int _spriteType;
    public float _spawnTime;
    public int _health;
    public float _speed;
}

