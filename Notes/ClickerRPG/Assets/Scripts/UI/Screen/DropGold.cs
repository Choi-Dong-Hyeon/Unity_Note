using System.Collections;
using UnityEngine;

public class DropGold : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        Managers._playerStat.GOLD++;
        Managers._playerStat.EXP += PlayerController._monHp._exp;
        Destroy(gameObject);
    }
}
