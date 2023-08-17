using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject _npcInven;

    private void OnTriggerEnter(Collider other)
    {

        _npcInven.SetActive(true);
    }

}
