using UnityEngine;

public class MonsterStat : BaseStat
{
    [SerializeField] int _id;
    public int ID { get { return _id; } set { _id = value; } }


    protected override void Init()
    {
        base.Init();
        MonsterStatData data = Managers.Instance.Data.LoadJson<MonsterStatData, int, MonstersStat>("StatData_Monster");
    }



}
