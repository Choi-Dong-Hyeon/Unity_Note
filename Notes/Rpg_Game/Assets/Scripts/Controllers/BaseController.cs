using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Define.State _state;
    protected Animator _anim;

    void Start()
    {
        Init();
    }

    void Update()
    {
        switch (_state)
        {
            case Define.State.Idle:
                IdleState();
                break;
            case Define.State.Run:
                RunState();
                break;
            case Define.State.Attack:
                AttackState();
                break;
            case Define.State.Attack_Tum:
                Attack_TumState();
                break;
            case Define.State.Attack_Kick:
                Attack_KickState();
                break;
            case Define.State.Die:
                DieState();
                break;
        }
    }

    protected virtual void Init() { _anim = GetComponent<Animator>(); }
    protected virtual void IdleState() {  _anim.CrossFade("Idle",0.07f); }
    protected virtual void RunState() { _anim.Play("Run"); }
    protected virtual void AttackState() { _anim.Play("Attack_Jab"); }
    protected virtual void Attack_KickState() { _anim.CrossFade("Attack_Kick", 0.01f); }
    protected virtual void Attack_TumState() { _anim.CrossFade("Attack_Tum",0.07f); }
    protected virtual void DieState() { _anim.Play("Die"); }

}
