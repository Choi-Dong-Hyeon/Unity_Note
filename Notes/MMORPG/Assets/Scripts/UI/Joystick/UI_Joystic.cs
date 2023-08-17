using System.Diagnostics;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class UI_Joystic : UI_Scene, IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    enum Images
    {
        BG,
        Handler,
        Icon
    }

    void Start()
    {
        Init();
        Get<Image>((int)Images.BG).name = "333";
    }

    float _handler;

    public override void Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Get<Image>((int)Images.BG).gameObject.transform.position = eventData.position;
        Get<Image>((int)Images.Handler).gameObject.transform.position = eventData.position;
        Get<Image>((int)Images.Icon).gameObject.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
