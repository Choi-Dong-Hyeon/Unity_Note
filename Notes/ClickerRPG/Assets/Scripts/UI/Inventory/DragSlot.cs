using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    public static DragSlot _instance;
    public Slot _dragSlot;
    public Image _image;
    public int lv;
    void Awake()
    {
        _instance = this;
    }

}
