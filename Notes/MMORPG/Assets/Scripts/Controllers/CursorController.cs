using UnityEngine;

public class CursorController : MonoBehaviour
{
    Texture2D _handIcon;
    Texture2D _attackIcon;
    void Start()
    {
        _handIcon = Managers.Resource.Load<Texture2D>("Art/Texturs/Cursor/Hand");
        _attackIcon = Managers.Resource.Load<Texture2D>("Art/Texturs/Cursor/Attack");
    }


    void Update()
    {

        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 dir = cam - Camera.main.transform.position;
        dir = dir.normalized;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100f, 1 << (int)Define.Layer.Monster))
        {
            Cursor.SetCursor(_attackIcon, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(_handIcon, Vector2.zero, CursorMode.Auto);
        }

    }
}
