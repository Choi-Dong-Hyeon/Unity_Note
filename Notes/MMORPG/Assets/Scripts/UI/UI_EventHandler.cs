using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IDragHandler, IPointerClickHandler, IPointerDownHandler
{
    public Action<PointerEventData> OnPointerDownAction;
    public Action<PointerEventData> OnPointerClickAction;
    public Action<PointerEventData> OnDragEventAction;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Ŭ�����ڸ���");
        if (OnPointerDownAction != null)
        {
            OnPointerDownAction.Invoke(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�巡��");
        if (OnPointerClickAction != null)
        {
            OnPointerClickAction.Invoke(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Ŭ����������");
        if (OnDragEventAction != null)
        {
            OnDragEventAction.Invoke(eventData);
        }
    }

}
