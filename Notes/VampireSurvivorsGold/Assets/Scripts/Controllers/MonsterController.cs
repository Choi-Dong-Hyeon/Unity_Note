using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float _health;
    public float _maxHealth;
    public RuntimeAnimatorController[] animCon;
    Animator anim;

    float _speed = 0.5f;
    public Rigidbody2D _targer;
    bool _isLive;
    Rigidbody2D _rb;
    SpriteRenderer _sprite;
    Collider2D coll;
    WaitForFixedUpdate wait;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
        wait = new WaitForFixedUpdate();
        anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!_isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) return;
        if (!Managers.instance.isLive) return;

        Vector2 dirVec = _targer.position - _rb.position;
        _rb.MovePosition(_rb.position + dirVec * _speed * Time.fixedDeltaTime);
        _rb.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!_isLive) return;
        if (!Managers.instance.isLive) return;

        _sprite.flipX = _targer.position.x < _rb.position.x;
    }

    private void OnEnable()
    {
        _targer = Managers.instance._player.GetComponent<Rigidbody2D>();
        _isLive = true;
        _isLive = true;
        coll.enabled = true;
        _rb.simulated = true;
        _sprite.sortingOrder = 2;
        anim.SetBool("Dead", false);
        _health = _maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data._spriteType];
        _speed = data._speed;
        _maxHealth = data._health;
        _health = data._health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")|| !_isLive) return;

        _health -= collision.GetComponent<Bullet>()._damage;
        StartCoroutine(KnockBack());
        if (_health > 0)
        {
            anim.Play("Hit");
        }
        else
        {
            _isLive = false;
            coll.enabled = false;
            _rb.simulated = false;
            _sprite.sortingOrder = 1;
            anim.SetBool("Dead",true);
            Managers.instance.kill++;
            Managers.instance.GetExp();
        
        }

    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = Managers.instance._player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        _rb.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);

    }

    void Dead()
    {
        gameObject.SetActive(false);
    }

}

