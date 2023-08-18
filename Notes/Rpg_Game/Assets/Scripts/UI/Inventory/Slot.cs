using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item _item;
    public Image _itemSprite;
    public Text _text;
    public Item_Info[] _items;
    int _textCount;

    public void AddItem(Item item,int count = 1)
    {
        _item = item;
        _itemSprite.sprite = item._itemSprite;
        _textCount = count;

        if (Define.ItemType.Use == item._itemType)
        {
            _text.gameObject.SetActive(true);
            _text.text = $"{_textCount}";
        }
        else
        {
            _text.text = null;
            _text.gameObject.SetActive(false);
        }
        _itemSprite.color = new Color(1, 1, 1, 1);
    }

    public void SetCount(int count=1)
    {
        _textCount += count;
        _text.text=$"{_textCount}";
        if (_textCount <= 0)
        {
            _text = null;
            _itemSprite.sprite = null;
            _textCount = default;
            _text.text = null;
            _text.gameObject.SetActive(false);
            _itemSprite.color = new Color(1, 1, 1, 0);
        }
    }
    
}
