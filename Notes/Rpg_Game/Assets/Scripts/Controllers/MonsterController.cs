using System.Collections;
using UnityEngine;

public class MonsterController : BaseController
{
    Vector3 dir=default;
    float dist = 35f;
    MonsterStat _monsterStat;
    public GameObject _dropItem;
    protected override void Init()
    {
        base.Init();
        dir = default;
        _monsterStat = GetComponent<MonsterStat>();
    }


    protected override void IdleState()
    {
        base.IdleState();
        if (_monsterStat.HP <= 0) _state = Define.State.Die;
        
        dir = Managers.player.gameObject.transform.position - transform.position;
        if (dir.magnitude < dist) _state = Define.State.Run;
 

    }

    protected override void AttackState()
    {
        base.AttackState();
        if (_monsterStat.HP <= 0) _state = Define.State.Die;
        dir = Managers.player.gameObject.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);

        if (dir.magnitude > 2.5f) _state = Define.State.Run;

    }

    protected override void RunState()
    {
        base.RunState();
        if (_monsterStat.HP <= 0) _state = Define.State.Die;
        dir = Managers.player.gameObject.transform.position - transform.position;

        if (dir.magnitude < 2.5f) _state = Define.State.Attack;
        if (dir.magnitude > dist) _state = Define.State.Idle;

        transform.position += dir.normalized * Time.deltaTime * _monsterStat.Speed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);


    }

    protected override void DieState()
    {
        base.DieState();
        StartCoroutine(DieTime());
    }

    IEnumerator DieTime()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        Instantiate(_dropItem, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(3.5f);
    }

    void MonsterRegen()
    {
        
    }


    public void MonsterAttack()
    {
        if (Managers.playerStat.PlayerHP > 0) Managers.playerStat.PlayerHP -= _monsterStat.Attack;
        else _state = Define.State.Idle;
    }

    

}
