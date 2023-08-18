using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = $"최고 점수 : {Managers._player.count}";
    }
}
