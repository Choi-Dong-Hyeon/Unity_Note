using UnityEngine;

public class Atcc : MonoBehaviour
{
    
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.GetComponent<MonsterController>().hp -= 30;

        }
    }

}
