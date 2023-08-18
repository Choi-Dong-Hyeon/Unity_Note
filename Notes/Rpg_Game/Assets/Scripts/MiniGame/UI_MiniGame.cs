using UnityEngine;
using UnityEngine.UI;

public class UI_MiniGame : MonoBehaviour
{

    public Button _button;
    public GameObject _Set;
    public GameObject _qustOK;
    void Update()
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("Cursor/Cursor_Hand"), Vector2.zero, CursorMode.Auto);
        if (Weapone._count > 35)
        {
            _button.gameObject.SetActive(true);
        }
    }

    public void GetOutButton()
    {
        _qustOK.SetActive(true);
        gameObject.SetActive(false);
    }

    public void GetOutButtons()
    {
        gameObject.SetActive(true);
        _Set.SetActive(false);
    }
}
