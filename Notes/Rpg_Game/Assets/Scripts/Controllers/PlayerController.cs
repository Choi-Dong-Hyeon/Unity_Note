using System.Collections;
using UnityEngine;

public class PlayerController : BaseController
{
    Vector3 _cam;
    Vector3 _dir;
    Vector3 _hitPoint;
    Vector3 _moveDir;
    PlayerStat _stat;
    public UI_Inventory _inventory;
    RaycastHit _monsterHit;


    protected override void Init()
    {
        base.Init();
        _stat = GetComponent<PlayerStat>();
        Managers.Input.KeyAction += OnKeyEvent;
    }

    void OnKeyEvent()
    {
        _cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        _dir = _cam - Camera.main.transform.position;
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, _dir.normalized, out hit, 100f, 1 << (int)Define.Layer.Ground))
        {
            Cursor.SetCursor(Resources.Load<Texture2D>("Cursor/Safe_Cursor"), Vector2.zero, CursorMode.Auto);
            _hitPoint = hit.point;
            _state = Define.State.Run;
        }
        else _state = Define.State.Idle;


    }

    protected override void IdleState()
    {
        base.IdleState();
    }

    protected override void RunState()
    {
        _moveDir = _hitPoint - transform.position;
        if (_moveDir.magnitude > 0.2f)
        {

            if (Physics.Raycast(transform.position + Vector3.up, _moveDir.normalized, out _monsterHit, 1f, 1 << (int)Define.Layer.Monster))
            {
                _state = Define.State.Attack;
                Cursor.SetCursor(Resources.Load<Texture2D>("Cursor/Sword"), Vector2.zero, CursorMode.Auto);
                transform.LookAt(_monsterHit.collider.transform);
                return;
            }


            transform.position += _moveDir.normalized * Time.deltaTime * _stat.PlayerSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDir), 20 * Time.deltaTime);
            base.RunState();

            if (Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.TransformDirection(Vector3.forward), 0.5f, 1 << (int)Define.Layer.Block))
            {
                Cursor.SetCursor(Resources.Load<Texture2D>("Cursor/Basic_Cursor"), Vector2.zero, CursorMode.Auto);
                _state = Define.State.Idle;
                return;
            }
        }
        else _state = Define.State.Idle;

    }

    protected override void AttackState()
    {
        if (Input.GetKeyDown(KeyCode.A) && _stat.JAPEXP > 1f) _state = Define.State.Attack_Kick;

        if (_monsterHit.collider.GetComponent<MonsterStat>().HP > 0)
        {
            base.AttackState();
        }
        else _state = Define.State.Idle;

    }

    protected override void Attack_KickState()
    {
        base.Attack_KickState();
        if (_monsterHit.collider.GetComponent<MonsterStat>().HP > 0)
        {
            base.Attack_KickState();
        }
        else _state = Define.State.Idle;
    }

    protected override void Attack_TumState()
    {
        base.Attack_TumState();
    }

    protected override void DieState()
    {
        base.DieState();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gold") | other.CompareTag("Item"))
        {
            Cursor.SetCursor(Resources.Load<Texture2D>("Cursor/Cursor_Item"), Vector2.zero, CursorMode.Auto);
            _inventory.GetItem(other.gameObject.GetComponent<Item_Info>().item);
            Destroy(other.gameObject);
        }
        else return;
    }


    public void OnAnimAttack()
    {
        _monsterHit.collider.GetComponent<MonsterStat>().HP -= _stat.PlayerAttack;

        _stat.JAPEXP += _monsterHit.collider.GetComponent<MonsterStat>().Exp;
    } 
    
    public void OnAnimKickAttack()
    {
        _monsterHit.collider.GetComponent<MonsterStat>().HP -= _stat.PlayerAttack*2;

        _stat.JAPEXP += _monsterHit.collider.GetComponent<MonsterStat>().Exp;
    }
}

