using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Animator _anim;
    protected Define.State _state;

    void Awake()
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
            case Define.State.Die:
                DieState();
                break;
        }
    }

    protected virtual void Init() { _anim = GetComponent<Animator>(); }
    protected virtual void IdleState() { _anim.CrossFade("Idle", 0.1f, 0); }
    protected virtual void RunState() { _anim.Play("Run"); }
    protected virtual void AttackState() { _anim.Play("Attack"); }
    protected virtual void DieState() { _anim.Play("Die"); }

}
