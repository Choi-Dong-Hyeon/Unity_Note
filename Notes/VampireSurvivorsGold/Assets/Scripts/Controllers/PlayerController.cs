using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 _inputVector;
    Rigidbody2D rb;
    float _moveSpeed = 8f;
    SpriteRenderer _sprite;
    Animator _anim;
    public Scanner scanner;

    public Hand[] hands;



    void Awake()
    {
        hands = GetComponentsInChildren<Hand>(true);
        rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    void Update()
    {
        if (!Managers.instance.isLive) return;

        _inputVector.x = Input.GetAxisRaw("Horizontal");
        _inputVector.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        if (!Managers.instance.isLive) return;
        rb.MovePosition(rb.position + _inputVector.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        if (!Managers.instance.isLive) return;
        if (Managers.instance.health < 0) return;

        if (_inputVector.x != 0)
        {
            _anim.Play("Run");
            _sprite.flipX = _inputVector.x < 0;
        }
        else _anim.Play("Stand");

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!Managers.instance.isLive) return;

        Managers.instance.health -= Time.deltaTime * 10;

        if (Managers.instance.health < 0)
        {
            for (int i = 2; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            _anim.Play("Dead");
            Managers.instance.GameOver();
        }

    }

}
