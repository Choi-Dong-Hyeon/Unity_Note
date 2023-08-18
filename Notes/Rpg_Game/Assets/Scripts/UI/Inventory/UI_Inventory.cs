using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Inventory : MonoBehaviour, IDragHandler
{
    public UI_Inventory _inventory;
    public GameObject _bg;
    public GameObject _grid;
    bool _activeSet;
    public Slot[] _slot;


    void Start()
    {
        _slot = _grid.GetComponentsInChildren<Slot>();
        _bg.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _activeSet = !_activeSet;
            if (_activeSet) _bg.SetActive(true);
            else _bg.SetActive(false);
        }
    }

    public void GetItem(Item item,int count=1)
    {
        if (Define.ItemType.Use == item._itemType)
        {
            for (int i = 0; i < _slot.Length; i++)
            {
                if (_slot[i]._item != null)
                {
                    if (_slot[i]._item._itemName == item._itemName)
                    {
                        _slot[i].SetCount(count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < _slot.Length; i++)
        {
            if (_slot[i]._item == null)
            {
                _slot[i].AddItem(item);
                return;
            }
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        _bg.transform.position = eventData.position;
    }

}
