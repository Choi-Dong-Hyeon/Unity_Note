using UnityEngine;
using UnityEngine.EventSystems;

public class BaseScene : MonoBehaviour
{
    protected Define.Scenes _scene = Define.Scenes.UnKnown;


    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        EventSystem evt = GameObject.FindObjectOfType<EventSystem>();
        if (evt == null)
        {
            evt = Managers.Instance.Resource.Instantiate<EventSystem>("@EventSystem");
        }
        DontDestroyOnLoad(evt);
    }

    protected virtual void Clear() { }

}
