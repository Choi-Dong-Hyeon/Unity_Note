using System.Collections;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{

    public GameObject _grid;
    public Slot[] _slots;
    public Item _item;
    void Awake()
    {
        _slots = _grid.GetComponentsInChildren<Slot>();
        _item._lv = 1;
    }

    void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    IEnumerator ItemSpawn()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i]._item == null)
                {
                    _slots[i].AddItem(Resources.Load<Item_Info>($"Prefabs/LV{_item._lv}Sword")._item);
                    break;
                }
            }
        }
    }

}
