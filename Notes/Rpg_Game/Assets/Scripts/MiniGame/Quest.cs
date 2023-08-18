using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject _quest;
   

    private void OnTriggerEnter(Collider other)
    {
        _quest.gameObject.SetActive(true);
    }
}
