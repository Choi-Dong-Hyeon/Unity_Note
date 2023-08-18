using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LvUp : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public Item _item;
    public Text _text;
    int _gold=1;

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.85f, 0.85f, 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
        if (Managers._playerStat.GOLD >= _gold)
        {
            _item._lv++;
            Managers._playerStat.GOLD -= 1;
            _gold++;
            _text.text = $"제작 검 레벨 증가\n 필요 골드 : {_gold}";
        }
    }
}