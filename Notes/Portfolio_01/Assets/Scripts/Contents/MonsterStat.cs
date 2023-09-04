using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : BaseStat
{
    [SerializeField] int _id;
    public int ID { get { return _id; } set { _id = value; } }


    protected override void Init()
    {
        base.Init();
        if (ID != 0)
            SetStat(ID);
        Managers.Instance.UI.ShowWorldSpaceUI<UI_HPBar>(gameObject.transform, "UI_HPBar");
    }

    public void SetStat(int id)
    {
        Dictionary<int, MonstersStat> monsterDic = Managers.Instance.Data.monsterStatDictionary;

        ID = monsterDic[id].id;
        Level = monsterDic[id].id;
        HP = monsterDic[id].hp;
        MaxHp = monsterDic[id].hp;
        Attack = monsterDic[id].attack;
        MoveSpeed = monsterDic[id].speed;

    }


}
