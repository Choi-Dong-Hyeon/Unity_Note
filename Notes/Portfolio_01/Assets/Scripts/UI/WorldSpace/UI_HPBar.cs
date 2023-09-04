using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : UI_Base
{

    enum Sliders
    {
        HPBar
    }

    BaseStat _stat;

    protected override void Init()
    {
        base.Init();
        Bind<Slider>(typeof(Sliders));
        _stat = transform.parent.GetComponent<BaseStat>();
    }

    void Update()
    {
        Transform parent = transform.parent;
        transform.position = parent.position + Vector3.up * parent.GetComponent<Collider>().bounds.size.y;
        transform.rotation = Camera.main.transform.rotation;
       
        SetHpRatio(_stat.HP);
    }

    void SetHpRatio(float ratio)
    {
        Get<Slider>((int)Sliders.HPBar).maxValue = _stat.MaxHp;
        Get<Slider>((int)Sliders.HPBar).value = ratio;
    }

}
