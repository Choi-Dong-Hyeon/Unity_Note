using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _walkSpeed;
    Rigidbody _myRigid;

    [SerializeField] float _lookSeneitivity;
    [SerializeField] float _CameraRotationLimit;
    [SerializeField] Camera theCamera;
    float currentCameraRotationX=default;


    void Awake()
    {
        _myRigid = GetComponent<Rigidbody>();
    }


    void Start()
    {

    }


    void Update()
    {
        Move();
        CameraRotation();
        CharacterRotation();
    }

    void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _chareaterRotationY = new Vector3(0f, _yRotation, 0f) * _lookSeneitivity;
        _myRigid.MoveRotation(_myRigid.rotation * Quaternion.Euler(_chareaterRotationY));
    }

    void CameraRotation()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * _lookSeneitivity;
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -_CameraRotationLimit, _CameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * _walkSpeed;
        _myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

}
