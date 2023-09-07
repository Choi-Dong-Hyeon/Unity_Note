using System.Collections;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    [SerializeField] int _monsterCount = 0;
    [SerializeField] int _keepMonsterCount = 0;
    [SerializeField] float _spawnRadius = 15f;
    [SerializeField] float _spawnTime = 10;
    [SerializeField] Vector3 _spawnPos;

    public void AddMonsterCount(int value)
    {
        _monsterCount += value;
    }

    public void KeepMonsterCount(int count)
    {
        _keepMonsterCount = count;
    }

    void Start()
    {
        Managers.Instance.Game.OnSpawnEvent += AddMonsterCount;
    }

    void Update()
    {
        while (_monsterCount < _keepMonsterCount)
        {
            StartCoroutine(ReserveSpawn());
        }
    }

    IEnumerator ReserveSpawn()
    {
        _monsterCount++;
        yield return new WaitForSeconds(Random.Range(0, _spawnTime));
        _monsterCount--;

        Vector3 ranPos;

        Vector3 ranDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
        ranDir.y = 0;
        ranPos = _spawnPos + ranDir;

        GameObject obj = Managers.Instance.Game.Spawn(Define.WorldObjects.Monster, "Monster_Bear");
        if (obj == null) yield break;

        obj.transform.position = ranPos;
    }
}