
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Souls : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Soul());
    }



    IEnumerator Soul()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(0.4f,1.5f));
            Instantiate(Resources.Load<GameObject>("Prefabs/Soul"),transform);
        }
    }
   
    
}
