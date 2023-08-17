using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] protected Vector3 _movePos;
    [SerializeField] protected Vector3 _moveDir;
    [SerializeField] protected Animator anim;
    protected  Define.PlayerState _playerState = Define.PlayerState.Idle;


    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {

    }

    void Update()
    {
        switch (_playerState)
        {
            case Define.PlayerState.Idle:
                IdleState();
                break;
            case Define.PlayerState.Moving:
                MovingState();
                break;
            case Define.PlayerState.Attack:
                AttackState();
                break;
        }
    }

    protected virtual void IdleState()
    {

    }
    protected virtual void MovingState()
    {

    }
    protected virtual void AttackState()
    {

    }

}
