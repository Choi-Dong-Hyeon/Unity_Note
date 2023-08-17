using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Slider _hpSlider;
    public Text _text;

    void Start()
    {
        _hpSlider = GetComponent<Slider>();    
    }

    void Update()
    {
        _hpSlider.value = Managers.playerStat.PlayerHP;
        _text.text = $"50 / {Managers.playerStat.PlayerHP}";
    }
}
