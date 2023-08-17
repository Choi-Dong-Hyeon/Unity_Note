using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_Use : MonoBehaviour, IPointerDownHandler
{
    Image _myImage;
    Text _myText;
   

    void Awake()
    {
        _myImage = GetComponent<Image>();
        _myText = GetComponentInChildren<Text>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_myImage.sprite.name == "Potion")
        {
            Managers.playerStat.PlayerHP += 10;

            if (Convert.ToInt32(_myText.text)< 2)
            {
                _myText.text = "0";
                _myText.gameObject.SetActive(false);
                _myImage.sprite = null;
                _myImage.color = new Color(1, 1, 1, 0);
            }
            else _myText.text = Convert.ToString( Convert.ToInt32(_myText.text) - 1);
            
        }
    }


}
