using UnityEngine;

public class DmgText : MonoBehaviour
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
            transform.position = new Vector3(692, 1995, 0);
            gameObject.SetActive(false);
        }
    }

}
