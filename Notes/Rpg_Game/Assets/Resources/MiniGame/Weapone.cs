using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapone : MonoBehaviour
{
    public GameObject _hert;
    public Text _score;
    public static int _count;

    void Start()
    {
        StartCoroutine(OnHert());
    }

    void Update()
    {
        _score.text = $"Score : {_count}";    
       
    }

    IEnumerator OnHert()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(1, 5));
            Managers.Resource.Instantiate<GameObject>("Hert", transform);
        }
    }
}
