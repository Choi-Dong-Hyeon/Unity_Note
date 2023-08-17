using UnityEngine.UI;

public class UI_HpBar : UI_Scene
{
    enum Sliders
    {
        Slider,
    }
    enum Texts
    {
        HpNumText
    }

    Stat _stat;
    void Start()
    {
        Bind<Slider>(typeof(Sliders));
        Bind<Text>(typeof(Texts));
        _stat = transform.parent.GetComponent<Stat>();
    }


    void Update()
    {
        float ratio = _stat.Hp / (float)_stat.MaxHp;
        SetHpRatio(ratio);
    }

    public void SetHpRatio(float ratio)
    {
        if (_stat.Hp < 0) _stat.Hp = 0;
        Get<Text>((int)Texts.HpNumText).text = $"{_stat.MaxHp}/{_stat.Hp}";
        Get<Slider>((int)Sliders.Slider).value = ratio;
    }
}
