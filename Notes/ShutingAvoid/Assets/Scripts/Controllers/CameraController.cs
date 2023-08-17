using UnityEngine;

public class CameraController : MonoBehaviour
{

    void Start()
    {

    }


    void LateUpdate()
    {
        transform.position = Managers._player.gameObject.transform.position + new Vector3(0, 0, -10);
        Camera.main.orthographicSize = 9;
    }
}
