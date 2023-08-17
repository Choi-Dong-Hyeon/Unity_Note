using UnityEngine;
using static Define;

public class MonsterController : BaseController
{

    [SerializeField] float _scanRange = 10;
    [SerializeField] float _attackRange = 2;
    GameObject player;
    protected override void Init()
    {

        base.Init();

    }

    protected override void IdleState()
    {

        anim.CrossFade("WAIT", 0.1f);
        player = GameObject.FindGameObjectWithTag("Player");
        float distance = (player.transform.position - transform.position).magnitude;
        PlayerStat targer = player.GetComponent<PlayerStat>();
        if (distance <= _scanRange && targer.Hp > 0)
        {
            _playerState = Define.PlayerState.Moving;
        }


    }


    protected override void MovingState()
    {
        _moveDir = player.transform.position - transform.position;
        if (_moveDir.magnitude < _attackRange)
        {
            _playerState = Define.PlayerState.Attack;
            transform.LookAt(player.transform);
            return;
        }
        else
        {
            transform.position += _moveDir.normalized * Time.deltaTime * 3f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDir), 20 * Time.deltaTime);
            anim.Play("RUN");
        }
    }



    protected override void AttackState()
    {

        anim.Play("ATTACK");
    }

    void OnHitEvent()
    {

        PlayerStat targer = player.GetComponent<PlayerStat>();
        if (targer.Hp < 0)
        {
            
            _playerState = Define.PlayerState.Idle;
        }

        if (targer.Hp > 0) _playerState = Define.PlayerState.Moving;

        Stat myStat = gameObject.GetComponent<Stat>();
        int damage = Mathf.Max(0, myStat.Attack - targer.Defense);
        targer.Hp -= damage;
    }
}



