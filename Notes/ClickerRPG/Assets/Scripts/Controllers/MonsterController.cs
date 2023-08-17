using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : BaseController
{
    public Text _monsterDmgText;
    MonsterStat _stat;
    public int _hp = 45;
    public int _exp = 10;
    protected override void Init()
    {
        base.Init();
        _stat = GetComponent<MonsterStat>();
    }

    protected override void RunState()
    {
        base.RunState();
        transform.position += Vector3.left * Time.deltaTime;
        if (Physics2D.Raycast(transform.position + Vector3.up * 0.5f, Vector3.left, 0.5f, LayerMask.GetMask("Player"))) _state = Define.State.Attack;
    }

    protected override void AttackState()
    {
        base.AttackState();
        if (!Physics2D.Raycast(transform.position + Vector3.up * 0.5f, Vector3.left, 0.5f, LayerMask.GetMask("Player"))) _state = Define.State.Run;
        if (_hp <= 0) _state = Define.State.Die;

    }

    protected override void DieState()
    {
        base.DieState();
        StartCoroutine(MonsterDie());
    }

    IEnumerator MonsterDie()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        //  gameObject.SetActive(false);
        Destroy(gameObject);
        Instantiate(Resources.Load<GameObject>("Prefabs/DropGold"), transform.position + Vector3.down * 0.5f, Quaternion.identity);

    }

    public void MonsterAttack()
    {
        _stat.Attack = Random.Range(1, 6);
        Managers._playerStat.HP -= _stat.Attack;

        _stat.Attack = Random.Range(1, 6);
        _monsterDmgText.text = $"{_stat.Attack}";
        _monsterDmgText.gameObject.SetActive(true);
    }
}
