using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler
{
    public Item _item;
    public Image _itemSprite;
    public Text _text;
  

    public void AddItem(Item item)
    {
        _item = item;
        _itemSprite.sprite = item._itemSprite;
        _text.gameObject.SetActive(true);
        _text.text = $"{item._lv}";
        _itemSprite.color = new Color(1, 1, 1, 1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_item == null) return;
        DragSlot._instance._dragSlot = this;
        DragSlot._instance._image.sprite = _itemSprite.sprite;
        DragSlot._instance.lv = _item._lv;
        DragSlot._instance._image.color = new Color(1, 1, 1, 1);
        DragSlot._instance.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        DragSlot._instance._dragSlot = null;
        DragSlot._instance._image.sprite = null;
        DragSlot._instance._image.color = new Color(1, 1, 1, 0);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_item == null) return;
        if (DragSlot._instance.lv == _item._lv)
        {
            if (_item._lv < 6)
            {
                int lvCount = 1 + _item._lv;
                AddItem(Resources.Load<Item_Info>($"Prefabs/LV{lvCount}Sword")._item);
                lvCount--;
                DragSlot._instance._dragSlot._item = null;
                DragSlot._instance._dragSlot._itemSprite.sprite = null;
                DragSlot._instance._dragSlot._text.gameObject.SetActive(false);
                DragSlot._instance._dragSlot._itemSprite.color = new Color(1, 1, 1, 0);
            }
            else { _item._lv = 1; }
        }
    }
}
