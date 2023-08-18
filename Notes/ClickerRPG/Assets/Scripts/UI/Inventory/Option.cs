using UnityEngine;
using UnityEngine.EventSystems;

public class Option : MonoBehaviour,IPointerClickHandler
{
    public GameObject _option;
    bool _setActive;
    public void OnPointerClick(PointerEventData eventData)
    {
        _setActive = !_setActive;
        if (_setActive) _option.SetActive(true);
        else _option.SetActive(false);
    }

}
