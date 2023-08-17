using UnityEngine;
using UnityEngine.UI;

public class Text_Abil : MonoBehaviour
{
    Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        if (_text != null) _text.text = $"격투 어빌리티 \n{Managers.playerStat.JAPEXP:#0.00}";
    }

    
}
