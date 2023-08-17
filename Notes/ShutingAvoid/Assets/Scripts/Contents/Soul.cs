using UnityEngine;

public class Soul : MonoBehaviour
{
    Vector3 _dir;
    public float dist = -19;

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 5f;
        _dir = Managers._player.gameObject.transform.position - transform.position;

        if (_dir.magnitude < dist) transform.position += _dir.normalized * Time.deltaTime;


        if (transform.position.y < -10) Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Managers._player.gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);
        Destroy(gameObject);
    }

}
