using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : BaseStat
{
    int _exp;
    int _gold;

    public int Exp
    {
        get { return _exp; }
        set
        {
            _exp = value;
        }
    }

    public int Gold { get { return _gold; } set { _gold = value; } }


    protected override void Init()
    {
        Level = 1;
       StatData data= Managers.Instance.Data.LoadJson<StatData, int, Stat>("StatData_Player");
    }




    public void SetStat(int level)
    {

    }

}
