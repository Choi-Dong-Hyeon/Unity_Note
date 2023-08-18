using UnityEngine;

public class MonsterStat : StatBase
{
    protected override void Init()
    {
        base.Init();
        HP = 45;
        Attack = Random.Range(1, 6);
        EXP = 10;
    }

}
