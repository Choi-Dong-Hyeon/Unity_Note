using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetItem : MonoBehaviour, IDropHandler
{
    public Image _image;
    public DragSlot _dragSlot;
   public int _at;
    public GameObject _eft;

    public void OnDrop(PointerEventData eventData)
    {
        _image.sprite = _dragSlot._image.sprite;
        _at = Managers._playerStat.Attack = Random.Range(2, 11) + _dragSlot.lv * 6;
        _image.color = new Color(1, 1, 1, 1);
        StartCoroutine(EFT());
    }

    IEnumerator EFT()
    {
        _eft.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        _eft.SetActive(false);
    }

}
