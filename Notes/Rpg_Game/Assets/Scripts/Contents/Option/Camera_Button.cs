using UnityEngine;

public class Camera_Button : MonoBehaviour
{
    public CameraController _cam;
    bool _camSet;
    public void OnCameraButton()
    {
        _camSet = !_camSet;
        if (_camSet) _cam._camera = Define.Camera.QuarterView;
        else _cam._camera = Define.Camera.Normal;
    }

}
