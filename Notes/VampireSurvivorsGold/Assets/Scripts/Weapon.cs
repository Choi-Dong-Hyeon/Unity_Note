using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int _id;
    public int _prefabId;
    public float _damage;
    public int _count;
    public float _speed;

    float _timer;
    PlayerController _player;

    void Awake()
    {
        _player = Managers.instance._player;
    }

  
    void Update()
    {
        if (!Managers.instance.isLive) return;

        switch (_id)
        {
            case 0:
                transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
                break;
            default:
                _timer += Time.deltaTime;
                if (_timer > _speed)
                {
                    _timer = 0f;
                    Fire();
                }
                break;
        }
        if (Input.GetButtonDown("Jump")) { LevelUp(10, 1); }
    }

    public void LevelUp(float damage, int count)
    {
        _damage = damage;
        _count += count;

        if (_id == 0) Batch();

        _player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    }


    public void Init(ItemData data)
    {
        name = "Weapon" + data.itemId;
        transform.parent = _player.transform;
        transform.localPosition = Vector3.zero;

        _id = data.itemId;
        _damage = data.baseDamage;
        _count = data.baseCount;

        for(int i=0; i < Managers.instance.Pool._prefabs.Length; i++)
        {
            if(data.projectile== Managers.instance.Pool._prefabs[i])
            {
                _prefabId = i;
                break;
            }
        }

        switch (_id)
        {
            case 0:
                _speed = -150;
                Batch();
                break;
            default:
                _speed = 0.3f;
                break;
        }
        Hand hand = _player.hands[(int)data.itemType];
        hand.sprite.sprite = data.hand;
        hand.gameObject.SetActive(true);

        _player.BroadcastMessage("ApplyGear",SendMessageOptions.DontRequireReceiver);
    }



    void Batch()
    {
        for (int i = 0; i < _count; i++)
        {
            Transform bullet;
            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = Managers.instance.Pool.Get(_prefabId).transform;
                bullet.parent = transform;
            }

            bullet.parent = transform;

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / _count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(_damage, -1, Vector3.zero);
        }
    }

    void Fire()
    {
        if (!_player.scanner._nearTarget) return;

        Vector3 targetPos = _player.scanner._nearTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = Managers.instance.Pool.Get(_prefabId).transform;
        bullet.position = transform.position;

        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(_damage, _count, dir);

    }
}
