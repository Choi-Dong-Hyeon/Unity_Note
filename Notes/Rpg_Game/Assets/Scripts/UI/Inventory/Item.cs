using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string _itemName;
    public Sprite _itemSprite;
    public Define.ItemType _itemType;
}
