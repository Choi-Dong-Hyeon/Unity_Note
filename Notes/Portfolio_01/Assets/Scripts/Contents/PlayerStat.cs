using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : BaseStat
{
    [SerializeField] int _exp;
    [SerializeField] int _gold;

    public int Gold { get { return _gold; } set { _gold = value; } }
    public int Exp
    {
        get { return _exp; }
        set
        {
            _exp = value;
            int leve = Level;
            while (true)
            {
                Debug.Log("asd");
                if (Managers.Instance.Data.playerStatDictionary.TryGetValue(leve + 1, out Stat stat) == false)
                    break;

                if (_exp < stat.totalExp)
                    break;

                leve++;
            }
            if (leve != Level)
            {
                Level = leve;
                SetStat(Level);
            }

        }
    }

   


    protected override void Init()
    {
        Level = 1;
        SetStat(Level);

        Dictionary<int, Stat> playerDic = Managers.Instance.Data.playerStatDictionary;
        Dictionary<int, MonstersStat> monsterDic = Managers.Instance.Data.monsterStatDictionary;
       
    }




    public void SetStat(int level)
    {
        StatData data = Managers.Instance.Data.LoadJson<StatData, int, Stat>("StatData_Player");

        Level = data.playerStats[level].level;
        HP = data.playerStats[level].maxhp;
        Attack = data.playerStats[level].attack;
        MoveSpeed = data.playerStats[level].speed;
    }

}
