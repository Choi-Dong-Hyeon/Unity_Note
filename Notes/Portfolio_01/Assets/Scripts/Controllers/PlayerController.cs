using UnityEngine;

public class PlayerController : BaseController
{
    Vector3 _hitPoint;
    Vector3 _moveDir;
    RaycastHit _hit;

    PlayerStat _playerStat;

    protected override void Init()
    {
        base.Init();
        Managers.Instance.Input.OnMouseAction += OnMouseEvent;
        Managers.Instance.UI.ShowWorldSpaceUI<UI_HPBar>(gameObject.transform, "UI_HPBar");
        _playerStat = GetComponent<PlayerStat>();
        _worldObject = Define.WorldObjects.Player;
    }

    protected override void IdleState()
    {
        base.IdleState();
    }

    protected override void RunState()
    {
        base.RunState();
        _moveDir = _hitPoint - transform.position;
        _moveDir.y = 0;

        if (_moveDir.magnitude > 0.3f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDir), 20f);
            transform.position += _moveDir.normalized * Time.deltaTime * _playerStat.MoveSpeed;
        }
        else _state = Define.State.Idle;

    }

    protected override void AttackState()
    {
        _moveDir = _hitPoint - transform.position;
        _moveDir.y = 0;
        if (_moveDir.magnitude > 2.3f)
        {
            base.RunState();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDir), 20f);
            transform.position += _moveDir.normalized * Time.deltaTime * _playerStat.MoveSpeed;
        }
        else
        {
            if (_target == null) _state = Define.State.Idle;
            base.AttackState();

        }
    }

    protected override void DieState()
    {
        base.DieState();
    }

    BaseStat _targetStat;

    public void OnHitEvent()
    {
        Debug.Log("공격이벤트발동");
        if (_target == null) return;
        Camera.main.GetComponent<CameraController>().cameraMode = Define.CameraMode.QuaterView;

        _targetStat = _target.GetComponent<BaseStat>();
        if (_targetStat.HP <= 0)
        {
            Managers.Instance.Game.Despawn(_target.gameObject);
            _state = Define.State.Idle;
        }
        _targetStat.OnAttack(_playerStat);
    }

    LayerMask _mask = 1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster;

    void OnMouseEvent()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 camDir = cam - Camera.main.transform.position;

        if (Physics.Raycast(Camera.main.transform.position, camDir, out _hit, 100f, _mask))
        {
            _hitPoint = _hit.point;

            if (_hit.collider.gameObject.layer == (int)Define.Layer.Ground)
            {
                _state = Define.State.Run;
            }
            if (_hit.collider.gameObject.layer == (int)Define.Layer.Monster)
            {
                _target = _hit.collider.gameObject;
                _state = Define.State.Attack;
            }

        }
    }
}
