using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_Info : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Managers.player._inventory.GetItem(item);
    }
}
