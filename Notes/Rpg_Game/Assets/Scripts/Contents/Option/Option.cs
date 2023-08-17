using UnityEngine;
using UnityEngine.EventSystems;

public class Option : MonoBehaviour ,IPointerDownHandler
{
    public GameObject _option;

    public void OnPointerDown(PointerEventData eventData)
    {
        _option.SetActive(true);    
    }
}
