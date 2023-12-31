using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Define.CameraMode cameraMode;
    [SerializeField] GameObject _player;
    public Vector3 _normalDist;
    public Vector3 _quaterViewDist;

    void Start()
    {
        _normalDist = new Vector3(0, 15, 12);
        _quaterViewDist = new Vector3(0, 8, 8);
    }

    void LateUpdate()
    {
        switch (cameraMode)
        {
            case Define.CameraMode.Normal:
                NormalMode();
                break;
            case Define.CameraMode.QuaterView:
                QuaterViewMode();
                break;
        }
    }

    void NormalMode()
    {
        if (_player == null) return;
        transform.position = _player.transform.position + _normalDist;
    }

    void QuaterViewMode()
    {
        transform.position = _player.transform.position + _quaterViewDist;
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }
}
