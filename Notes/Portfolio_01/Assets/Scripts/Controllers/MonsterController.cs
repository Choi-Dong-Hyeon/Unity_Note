using UnityEngine;

public class MonsterController : BaseController
{
    [SerializeField] int _scanRange = 10;
    [SerializeField] float _attackRange = 2f;
    Vector3 dir;
    BaseStat _monsterStat;
    GameObject player;

    protected override void Init()
    {
        base.Init();
        _monsterStat = GetComponent<BaseStat>();
    }

    protected override void IdleState()
    {
        base.IdleState();

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        dir = player.transform.position - transform.position;
        if (_scanRange >= dir.magnitude)
        {
            _target = player;
            _state = Define.State.Run;
        }

    }

    protected override void RunState()
    {
        base.RunState();
        Debug.Log("Run");

        dir = player.transform.position - transform.position;
        if (dir.magnitude <= _attackRange)
            _state = Define.State.Attack;

        if (dir.magnitude <= _scanRange)
        {
            transform.position += dir.normalized * Time.deltaTime * _monsterStat.MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 30f * Time.deltaTime);
        }
        else _state = Define.State.Idle;


    }

    protected override void AttackState()
    {
        base.AttackState();
        Debug.Log("Attack");
        dir = player.transform.position - transform.position;
        if (dir.magnitude > _attackRange)
            _state = Define.State.Run;
    }

    protected override void DieState()
    {
        base.DieState();
    }


    public void MonsterOnHitEvent()
    {
        if (player == null) return;

        BaseStat targetStat = player.GetComponent<BaseStat>();
        if (targetStat.HP > 0)
        {
            targetStat.HP -= _monsterStat.Attack;
        }
        else
        {
            _state = Define.State.Idle;
        }
    }
}
