using UnityEngine;
using UnityEngine.UI;

public class GameTutorial : MonoBehaviour
{
    private void Update()
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("Cursor/Cursor_Hand"), Vector2.zero, CursorMode.Auto);
    }

    public void OnClick()
    {
        gameObject.SetActive(false);
    }
}
