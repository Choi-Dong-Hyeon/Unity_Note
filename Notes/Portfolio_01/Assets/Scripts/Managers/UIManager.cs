using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 50;

    public void PopupSetCanvas(GameObject go)
    {
        Canvas canvas = go.GetComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = _order;
        _order++;
    }

    public void SceneSetCanvas(GameObject go)
    {
        Canvas canvas = go.GetComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    Stack<UI_Popup> stack = new Stack<UI_Popup>();

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject root = GameObject.Find("@UI_Root");
        if (root == null)
            root = new GameObject { name = "@UI_Root" };

        GameObject go = Managers.Instance.Resource.Instantiate<T>($"UI/Popup/{name}", root.transform).gameObject;
        T popup = go.GetComponent<T>();

        if (popup == null)
            popup = go.AddComponent<T>();

        stack.Push(popup);
        return popup;
    }



    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject root = GameObject.Find("@UI_Root");
        if (root == null)
            root = new GameObject { name = "@UI_Root" };

        GameObject go = Managers.Instance.Resource.Instantiate<T>($"UI/Scene/{name}", root.transform).gameObject;

        T scene = go.GetComponent<T>();

        if (scene == null)
            scene = go.AddComponent<T>();

        return scene;
    }

    public void ClosePopupUI()
    {
        if (stack.Count == 0) return;
        UI_Popup popup = stack.Pop();
        Managers.Instance.Resource.Destroy(popup.gameObject);
        _order--;
    }

}
