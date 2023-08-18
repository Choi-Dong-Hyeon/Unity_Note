using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Define.CameraMode _mode = Define.CameraMode.QuaterView;
    [SerializeField] GameObject _player;
    [SerializeField] Vector3 _delta;
    RaycastHit hit;

    void LateUpdate()
    {
        switch (_mode)
        {
            case Define.CameraMode.QuaterView:
                QuaterView();
                break;
            case Define.CameraMode.ColliderView:
                ColliderView();
                break;
        }
    }

    void QuaterView()
    {
        transform.position = _player.transform.position + _delta;
        transform.LookAt(_player.transform.position+Vector3.up);
        if (Physics.Raycast(_player.transform.position + Vector3.up, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Block")))
            _mode = Define.CameraMode.ColliderView;
    }

    void ColliderView()
    {
        if (Physics.Raycast(_player.transform.position + Vector3.up, _delta, out hit, 100f, LayerMask.GetMask("Block")))
        {
            float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
            transform.position = _player.transform.position+Vector3.up + _delta.normalized * dist;
        }
        else _mode = Define.CameraMode.QuaterView;
    }
}
