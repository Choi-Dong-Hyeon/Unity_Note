using System.Collections;
using UnityEngine;

public class Root_Monster : MonoBehaviour
{

    public GameObject[] _MonsTers;

    void Start()
    {
        StartCoroutine(Weapone());

    }

    IEnumerator Weapone()
    {
        while (true)
        {
            Instantiate(_MonsTers[Random.Range(0,3)], transform).gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(Random.Range(2,7));
        }
    }

}
