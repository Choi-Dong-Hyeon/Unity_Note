using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class HUD : MonoBehaviour
{
    public enum InfoType
    {
        Exp,
        Level,
        Kill,
        Time,
        Health,
    }

    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = Managers.instance.exp;
                float maxExp = Managers.instance.nextExp[Mathf.Min(Managers.instance.level, Managers.instance.nextExp.Length - 1)];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", Managers.instance.level);
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", Managers.instance.kill);
                break;
            case InfoType.Time:
                float remainTime = Managers.instance._maxGameTime - Managers.instance._gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                float curHealth = Managers.instance.health;
                float maxHealth = Managers.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;

        }
    }

}
