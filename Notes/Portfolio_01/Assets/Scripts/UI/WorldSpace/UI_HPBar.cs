using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : UI_Base
{
    enum Sliders
    {
        HPBar
    }

    enum Texts
    {
        EmailName,
    }

    BaseStat _stat;

    protected override void Init()
    {
        base.Init();
        Bind<Slider>(typeof(Sliders));
        Bind<Text>(typeof(Texts));
        _stat = transform.parent.GetComponent<BaseStat>();
      //  Get<Text>((int)Texts.EmailName).text = Managers.Instance.Fire._user.Email; HP위에 이메일아이디 표시
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
