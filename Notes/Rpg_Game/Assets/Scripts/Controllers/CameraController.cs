using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 _positionDist;
    public Vector3 _rotationDist;
    public Define.Camera _camera;

    void LateUpdate()
    {
        switch (_camera)
        {
            case Define.Camera.Normal:
                NormalCamera();
                break;
            case Define.Camera.QuarterView:
                QuarterViewCamera();
                break;
        }
    }

    void NormalCamera()
    {
        transform.position = Managers.player.transform.position + _positionDist;
        transform.eulerAngles = new Vector3(31, 0, 0);
    }

    void QuarterViewCamera()
    {
        transform.position = Managers.player.transform.position + new Vector3(0, 15f, 20f);
        transform.eulerAngles =  _rotationDist;
    }

}
