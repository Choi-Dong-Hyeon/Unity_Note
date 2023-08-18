using UnityEngine;

public class MonsterStat : BaseStat
{
    [SerializeField] int _attack;
    [SerializeField] int _hp;
    [SerializeField] float _speed;
    [SerializeField] float _exp;
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int HP { get { return _hp; } set { _hp = value; } }
    public float Speed { get { return _speed; } set { _speed = value; } }
    public float Exp { get { return _exp; } set { _exp = value; } }

    //protected override void Init()
    //{
    //    base.Init();
    //    Attack = 6;
    //    Exp = 0.03f;
    //    HP = 30;
    //    Speed = 3f;
    //}

}
