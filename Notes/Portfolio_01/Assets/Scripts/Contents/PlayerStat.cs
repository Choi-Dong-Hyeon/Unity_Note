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
                if (Managers.Instance.Data.playerStatDictionary.TryGetValue(leve + 1, out Stat stat) == false)
                    break;
                if (_exp < stat.totalExp)
                    break;
                leve++;
            }
            if (leve != Level)
            {
                //·¹º§¾÷
                Level = leve;
                SetStat(Level);
            }
        }
    }


    protected override void Init()
    {
        Level = 1;
        SetStat(Level);
    }

    void SetStat(int level)
    {
        Dictionary<int, Stat> playerDic = Managers.Instance.Data.playerStatDictionary;

        Level = playerDic[level].level;
        HP = playerDic[level].maxhp;
        Attack = playerDic[level].attack;
        MoveSpeed = playerDic[level].speed;
        Exp = playerDic[level].totalExp;
    }

}
