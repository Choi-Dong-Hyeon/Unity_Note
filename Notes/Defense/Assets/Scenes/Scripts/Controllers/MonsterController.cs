using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{

    Vector3 dir;

    public int hp = 100;
    
    void Update()
    {
        dir = GetComponentInParent<MonsterWeapon>().Wall.transform.position - transform.position;
        if (dir.magnitude > 0.5f) transform.position += dir.normalized * Time.deltaTime * 4f;

        if (hp <= 0)
        {
            PlayerController._player.score.text = $"처치 몬스터 : {PlayerController._player.count++}";
            Destroy(gameObject);
        }

  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.4f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            GetComponentInParent<MonsterWeapon>().slider.value -= 0.1f;
            yield return new WaitForSecondsRealtime(0.5f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp -= 30;
        StartCoroutine(Att());
    }

    IEnumerator Att()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSecondsRealtime(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
