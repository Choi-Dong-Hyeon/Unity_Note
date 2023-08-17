using UnityEngine;
using UnityEngine.EventSystems;

public class QustOkX : MonoBehaviour,IPointerDownHandler
{

    public GameObject _parent;
    public void OnPointerDown(PointerEventData eventData)
    {
        _parent.SetActive(false);
    }


}
