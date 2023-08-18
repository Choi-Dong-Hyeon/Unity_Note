using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 4f;

        if (transform.position.y < -10)
        {
            Managers._player.score.text = $"Á¡¼ö : {Managers._player.count++}";
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Managers._player.transform.localScale -= new Vector3(0.5f, 0.5f, 0);
    }



}
