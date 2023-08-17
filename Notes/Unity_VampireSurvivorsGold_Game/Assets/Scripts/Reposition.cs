using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D _coll;

    void Awake()
    {
        _coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) return;

        Vector3 _playerPos = Managers.instance._player.transform.position;
        Vector3 _myPos = transform.position;

        float difX = Mathf.Abs(_playerPos.x - _myPos.x);
        float difY = Mathf.Abs(_playerPos.y - _myPos.y);

        Vector3 _playerDir = Managers.instance._player._inputVector;
        float dirX = _playerDir.x < 0 ? -1 : 1;
        float dirY = _playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (difX > difY) transform.Translate(Vector3.right * dirX * 40);
                else if (difX < difY) transform.Translate(Vector3.up * dirY * 40);
                break;

            case "Enemy":
                if (_coll.enabled) transform.Translate(_playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                break;
        }
    }


}
