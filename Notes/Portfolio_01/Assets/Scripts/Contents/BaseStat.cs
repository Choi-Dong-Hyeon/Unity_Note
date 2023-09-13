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
    [SerializeField] int _getExp;

    public int Level { get { return _level; } set { _level = value; } }
    public int HP { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxhp; } set { _maxhp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int GetExp { get { return _getExp; } set { _getExp = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    void Awake()
    {
        Init();
    }

    protected virtual void Init() { }


    public virtual void OnAttack(BaseStat baseStat)
    {
        HP -= baseStat.Attack;
        if (HP <= 0)
        {
            Camera.main.GetComponent<CameraController>().cameraMode = Define.CameraMode.Normal;
            HP = 0;
            OnDie(baseStat);
        }
    }

    void OnDie(BaseStat baseStat)
    {
        Define.WorldObjects type = Managers.Instance.Game.GetWorldObjectType(baseStat.gameObject);
        if (type == Define.WorldObjects.Player)
        {
            PlayerStat playerStat = baseStat as PlayerStat;

            playerStat.Exp += GetExp;
        }
        Managers.Instance.Game.Despawn(gameObject);
    }
}



