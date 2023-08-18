using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string _itemName;
    public Sprite _itemSprite;
    public int _lv = 1;
}
