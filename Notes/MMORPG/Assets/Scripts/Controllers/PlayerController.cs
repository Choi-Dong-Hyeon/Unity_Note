using UnityEngine;

public class PlayerController : BaseController
{
    PlayerStat _stat;

    protected override void Init()
    {
        base.Init();
        Managers.Input.MouseAction += OnMouseEvent;
        _stat = GetComponent<PlayerStat>();
        anim = GetComponent<Animator>();
    }

    protected override void AttackState()
    {
        anim.Play("ATTACK");
    }

    protected override void IdleState()
    {
        anim.CrossFade("WAIT", 0.1f);
    }

    protected override void MovingState()
    {
        _moveDir = _movePos - transform.position;
        if (_moveDir.magnitude > 0.1f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, _moveDir, out hit, 1f, 1 << (int)Define.Layer.Monster))
            {
                _playerState = Define.PlayerState.Attack;
                transform.LookAt(hit.collider.transform);
                return;
            }

            transform.position += _moveDir.normalized * Time.deltaTime * _stat.MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDir), 20 * Time.deltaTime);
            anim.Play("RUN");


            if (Physics.Raycast(transform.position + Vector3.up, _moveDir, out hit, 1f, 1 << (int)Define.Layer.Block))
            {
                _playerState = Define.PlayerState.Idle;
                return;
            }
        }
        else _playerState = Define.PlayerState.Idle;


    }


    void OnHitEvent()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, _moveDir, out hit, 1f, 1 << (int)Define.Layer.Monster))
        {
            Stat targer = hit.collider.GetComponent<Stat>();
            PlayerStat myStat = gameObject.GetComponent<PlayerStat>();
            int damage = Mathf.Max(0, myStat.Attack - targer.Defense);
            Debug.Log(damage);
            targer.Hp -= damage;
            if (targer.Hp < 0) Destroy(targer.gameObject);
        }

    }

    void OnMouseEvent(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click) return;

        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 dir = cam - Camera.main.transform.position;
        dir = dir.normalized;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100f, 1 << (int)Define.Layer.Ground))
        {
            _movePos = hit.point;
            _playerState = Define.PlayerState.Moving;
        }

    }



}
