
public class PlayerStat : StatBase
{
 

    protected override void Init()
    {
        base.Init();
        HP = 300;
        Attack = UnityEngine.Random.Range(2, 11);
        EXP = 0;
        GOLD = 0;
    }
}
