using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 _movePos;
    Vector3 _moveDir;
    float _speed = 7f;
    Animator anim;
    Define.PlayerState _playerState = Define.PlayerState.Idle;


    void Start()
    {
        anim = GetComponent<Animator>();
        Managers.Input.MouseAction += OnMouseEvent;
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
        }

    }

    void IdleState()
    {
        anim.Play("WAIT");
    }

    void MovingState()
    {
        _moveDir = _movePos - transform.position;
        if (_moveDir.magnitude > 0.1f)
        {
            transform.position += _moveDir.normalized * Time.deltaTime * _speed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDir), 20 * Time.deltaTime);
            anim.Play("RUN");
        }
        else _playerState = Define.PlayerState.Idle;
    }

    void OnMouseEvent(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click) return;

        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 dir = cam - Camera.main.transform.position;
        dir = dir.normalized;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100f, LayerMask.GetMask("Ground")))
        {
            _movePos = hit.point;
            _playerState = Define.PlayerState.Moving;
        }
    }

}
