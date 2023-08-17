using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10;

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = go.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else canvas.sortingOrder = 0;

    }



    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = go.GetComponent<T>();
        _popupStack.Push(popup);

        GameObject root = GameObject.Find("@UI_Root");
        if (root == null) root = new GameObject { name = "@UI_Root" };
        go.transform.SetParent(root.transform);

        return popup;
    }


    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name)) name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = go.GetComponent<T>();

        GameObject root = GameObject.Find("@UI_Root");
        if (root == null) root = new GameObject { name = "@UI_Root" };
        go.transform.SetParent(root.transform);

        return sceneUI;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0) return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        _order--;
    }


}
