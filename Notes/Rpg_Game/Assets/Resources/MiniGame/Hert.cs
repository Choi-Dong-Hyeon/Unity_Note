using System.Collections;
using UnityEngine;

public class Hert : MonoBehaviour
{
   

    void Start()
    {
        StartCoroutine(Die());
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 140f;
    }


    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(4f);
        Weapone._count++;
        Destroy(gameObject);
    }
}
