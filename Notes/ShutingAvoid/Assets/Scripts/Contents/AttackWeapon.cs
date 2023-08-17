using System.Collections;
using UnityEngine;

public class AttackWeapon : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(AttackWeapons());
    }


    IEnumerator AttackWeapons()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(2f, 2.6f));
            Instantiate(Resources.Load<GameObject>("Prefabs/Attack"), transform) ;
        }
    }

}
