using UnityEngine;

public class MonsterController : BaseController
{
    [SerializeField] int _scanRange = 10;
    [SerializeField] float _attackRange = 2f;
    BaseStat _monsterStat;
    GameObject _player;
    Vector3 _dir;

    protected override void Init()
    {
        base.Init();
        _worldObject = Define.WorldObjects.Monster;
        _monsterStat = GetComponent<BaseStat>();
    }

    protected override void IdleState()
    {
        base.IdleState();

        _player = Managers.Instance.Game._players;
        if (_player == null) return;

        _dir = _player.transform.position - transform.position;
        if (_scanRange >= _dir.magnitude)
        {
            _target = _player;
            _state = Define.State.Run;
        }
    }

    protected override void RunState()
    {
        base.RunState();
        Debug.Log("Run");

        _dir = _player.transform.position - transform.position;
        if (_dir.magnitude <= _attackRange)
            _state = Define.State.Attack;

        if (_dir.magnitude <= _scanRange)
        {
            transform.position += _dir.normalized * Time.deltaTime * _monsterStat.MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_dir), 30f * Time.deltaTime);
        }
        else _state = Define.State.Idle;


    }

    protected override void AttackState()
    {
        if (_target != null)
        {

            base.AttackState();
            Debug.Log("Attack");

            _dir = _player.transform.position - transform.position;
            if (_dir.magnitude > _attackRange)
                _state = Define.State.Run;
        }
        else
            _state = Define.State.Idle;
    }

    protected override void DieState()
    {
        base.DieState();
    }

    BaseStat targetStat;

    public void MonsterOnHitEvent()
    {
        if (_target == null) return;

        targetStat = _player.GetComponent<BaseStat>();

        targetStat.OnAttack(_monsterStat);
    }
}
