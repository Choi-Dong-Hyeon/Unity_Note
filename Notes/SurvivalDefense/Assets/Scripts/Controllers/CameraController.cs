using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    float _sensitivity=1f;
    float _limit=45f;
    float _rotationX;
    float _currentRotationX;
    void Start()
    {

    }


    void LateUpdate()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        float rotation = Input.GetAxisRaw("Mouse Y");
        float rotationX = _rotationX * _sensitivity;
        _currentRotationX += rotationX;
        _currentRotationX = Mathf.Clamp(_currentRotationX, -_limit, _limit);
        gameObject.transform.localEulerAngles = new Vector3(_currentRotationX, 0f, 0f);
    }
}
