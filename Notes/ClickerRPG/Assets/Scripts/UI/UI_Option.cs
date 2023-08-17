using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Option : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

}
