using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField] int _exp;
    [SerializeField] int _gold;

    public int Exp { get { return _exp; } set { _exp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }
    void Start()
    {
        _level = 1;
        _hp = 50;
        _maxHp = 50;
        _attack = 4;
        _defense = 0;
        _moveSpeed = 5f;
        _exp = 0;
        _gold = 0;
    }
}
