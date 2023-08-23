using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour ,IPointerDownHandler ,IDragHandler ,IEndDragHandler ,IDropHandler
{
    public delegate void PointerDownHandler(PointerEventData eventData);
    public DropHandler pointerDownHandler;

    public delegate void DragHandler(PointerEventData eventData);
    public DragHandler dragHandler;

    public delegate void EndDragHandler(PointerEventData eventData);
    public EndDragHandler endDragHandler; 

    public delegate void DropHandler(PointerEventData eventData);
    public DropHandler dropHandler; 
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (pointerDownHandler != null)
        {
            pointerDownHandler.Invoke(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragHandler != null)
        {
            dragHandler.Invoke(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (endDragHandler != null)
        {
            endDragHandler.Invoke(eventData);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (dropHandler != null)
        {
            dropHandler.Invoke(eventData);
        }
    }

   
}
