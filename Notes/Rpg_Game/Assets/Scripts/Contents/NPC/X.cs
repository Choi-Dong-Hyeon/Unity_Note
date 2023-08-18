using UnityEngine;
using UnityEngine.EventSystems;

public class X : MonoBehaviour ,IPointerDownHandler
{
    
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.transform.parent.gameObject.SetActive(false);   
    }

}
