using UnityEngine;

public class Magnet : MonoBehaviour
{
 
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Resources.Load<GameObject>("Prefabs/Soul").GetComponent<Soul>().dist = 100;
        Destroy(gameObject);
    }

}
