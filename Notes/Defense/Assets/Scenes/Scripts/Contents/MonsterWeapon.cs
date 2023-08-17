using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterWeapon : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();    

    public Slider slider;

    public Transform Wall;


    void Start()
    {
        StartCoroutine(MonterWeapon());
    }

    IEnumerator MonterWeapon()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(1.5f,3f));
            Instantiate(list[Random.Range(0,2)], transform);
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
