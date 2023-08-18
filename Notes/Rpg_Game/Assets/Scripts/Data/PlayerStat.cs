using UnityEngine;

public class PlayerStat : BaseStat
{
    [SerializeField] int _hp;
    [SerializeField] float _japExp;
    [SerializeField] int _playerAttack;
    [SerializeField] float _playerSpeed;

    public int PlayerHP { get { return _hp; } set { _hp = value; } }
    public float JAPEXP { get { return _japExp; } set { _japExp = value; } }
    public int PlayerAttack { get { return _playerAttack; } set { _playerAttack = value; } }
    public float PlayerSpeed { get { return _playerSpeed; } set { _playerSpeed = value; } }


    protected override void Init()
    {
        base.Init();

        PlayerHP = 50;
        JAPEXP = 0.00f;
        PlayerAttack = 10;
        PlayerSpeed = 6.5f;
    }
}
