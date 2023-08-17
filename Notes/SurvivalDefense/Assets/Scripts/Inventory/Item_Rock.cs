using UnityEngine;

public class Item_Rock : MonoBehaviour
{
    public Item item;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item._itemSprite;    
    }
}
