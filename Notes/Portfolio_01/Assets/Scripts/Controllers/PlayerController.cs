using UnityEngine;

public class PlayerController : BaseController
{
    Vector3 _hitPoint;
    Vector3 _moveDir;
    RaycastHit _hit;

    protected override void Init()
    {
        base.Init();
        Managers.Instance.Input.OnMouseAction += OnMouseEvent;

       
    }

    protected override void IdleState()
    {
        base.IdleState();
    }




    protected override void RunState()
    {
        base.RunState();
        _moveDir = _hitPoint - transform.position;

        if (_moveDir.magnitude > 0.3f)
        {
            transform.position += _moveDir.normalized * Time.deltaTime * 2f;
        }
        else _state = Define.State.Idle;




    }

    protected override void AttackState()
    {
        base.AttackState();
    }
    protected override void DieState()
    {
        base.DieState();
    }








    void OnMouseEvent()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 camDir = cam - Camera.main.transform.position;

        if (Physics.Raycast(Camera.main.transform.position, camDir, out _hit, 100f, 1 << (int)Define.Layer.Ground))
        {
            _hitPoint = _hit.point;
            _state = Define.State.Run;

        }
    }
}
