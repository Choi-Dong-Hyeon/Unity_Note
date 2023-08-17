using UnityEngine;

public class MapController : MonoBehaviour
{

    void Update()
    {
        if (transform.position.x < -15)
        {
            transform.position = new Vector3(73, 0, 0);
        }

        transform.position += Vector3.left * Time.deltaTime * 3f;
    }
}
