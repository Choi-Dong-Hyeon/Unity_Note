using UnityEngine;

public class MonsterController : MonoBehaviour
{
    Vector3 dir;
    float dist = 4;
    float _speed = 3f;

  
    void Update()
    {
        dir = Managers._player.gameObject.transform.position - transform.position;
        if (dir.magnitude < dist)
        {
            if (dir.magnitude > 1.5f) transform.position += dir.normalized * Time.deltaTime * _speed;
        }
    }
}
