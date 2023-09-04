using UnityEngine;

public class CursorController : MonoBehaviour
{
    Define.CursorType _cursorType;
    RaycastHit _hit;
    Texture2D _baseCursor;
    Texture2D _attackCursor;

    void Start()
    {
        _baseCursor = Managers.Instance.Resource.Load<Texture2D>("Art/Cursor/Cursor_1");
        _attackCursor = Managers.Instance.Resource.Load<Texture2D>("Art/Cursor/Attack");
    }

    LayerMask _mask = 1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster;

    void Update()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 camDir = cam - Camera.main.transform.position;

        if (Physics.Raycast(Camera.main.transform.position, camDir, out _hit, 100f, _mask))
        {
            if (_hit.collider.gameObject.layer == (int)Define.Layer.Ground)
            {
                if (_cursorType != Define.CursorType.Attack)
                {
                    Cursor.SetCursor(_baseCursor, Vector2.zero, CursorMode.Auto);
                    _cursorType = Define.CursorType.Attack;
                }
            }
            if (_hit.collider.gameObject.layer == (int)Define.Layer.Monster)
            {
                if (_cursorType != Define.CursorType.Base)
                {
                    Cursor.SetCursor(_attackCursor, Vector2.zero, CursorMode.Auto);
                    _cursorType = Define.CursorType.Base;
                }
            }
        }
    }
}
