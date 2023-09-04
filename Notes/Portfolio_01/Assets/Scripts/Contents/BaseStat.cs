using System;
using UnityEngine;

[Serializable]
public class BaseStat : MonoBehaviour
{

    [SerializeField] int _level;
    [SerializeField] int _hp;
    [SerializeField] int _maxhp;
    [SerializeField] int _attack;
    [SerializeField] float _moveSpeed;


    public int Level { get { return _level; } set { _level = value; } }
    public int HP { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxhp; } set { _maxhp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }


    void Awake()
    {
        Init();
    }

    protected virtual void Init() { }

}



