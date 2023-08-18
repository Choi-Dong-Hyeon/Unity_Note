using UnityEngine;

public class MonsterDmgText : MonoBehaviour
{
    float _t;

    private void Start()
    {
        _t = 0.65f;
    }

    void Update()
    {
        if (_t > Time.time) transform.position += Vector3.up * 2f;
        else
        {
            _t = Time.time + 0.65f;
            transform.position = new Vector3(251, 2000, 0);
            gameObject.SetActive(false);
        }
    }
}
