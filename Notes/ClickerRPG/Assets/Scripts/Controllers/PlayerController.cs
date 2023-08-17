using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseController
{
    public Slider _hpSlider;
    public Slider _expSlider;
    public Text _dmgText;
    PlayerStat _stat;
    public Text _goldText;
    public static MonsterController _monHp;
    public GetItem _getItem;

    protected override void Init()
    {
        base.Init();
        _stat = GetComponent<PlayerStat>();
        _hpSlider.maxValue = _stat.HP;
        _hpSlider.value = _stat.HP;

        _expSlider.maxValue = 100;
        _expSlider.value = _stat.EXP;
        _goldText.text = $"{_stat.GOLD}";
    }

    protected override void RunState()
    {
        base.RunState();
        _hpSlider.value = _stat.HP;
        _expSlider.value = _stat.EXP;
        _goldText.text = $"{_stat.GOLD}";
        if (Physics2D.Raycast(transform.position + Vector3.up * 0.5f, Vector3.right, 1f, LayerMask.GetMask("Monster"))) _state = Define.State.Attack;
    }


    protected override void AttackState()
    {
        base.AttackState();
        _hpSlider.value = _stat.HP;
        _expSlider.value = _stat.EXP;
        _goldText.text = $"{_stat.GOLD}";
        if (Physics2D.Raycast(transform.position + Vector3.up * 0.5f, Vector3.right, 1f, LayerMask.GetMask("Monster"))) _state = Define.State.Attack;
        else _state = Define.State.Run;
    }

    protected override void DieState()
    {
        base.DieState();
    }

    public void AnimOnAttack()
    {
        if (_monHp == null) return;
        _stat.Attack = _getItem._at + Random.Range(1, 10);
        if (_monHp != null) _monHp._hp -= _stat.Attack;
        _dmgText.text = $"{_stat.Attack}";
        _dmgText.gameObject.SetActive(true);
        _monHp.gameObject.transform.localScale += new Vector3(-0.01f, -0.01f, 0);
        if (_monHp != null) StartCoroutine(MonsterAtc());

    }

    IEnumerator MonsterAtc()
    {
        _monHp.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSecondsRealtime(0.1f);
        _monHp.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        _monHp = null;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        _monHp = collision.GetComponent<MonsterController>();
    }


}
