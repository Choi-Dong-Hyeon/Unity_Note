using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = $"�ְ� ���� : {Managers._player.count}";
    }
}
