using UnityEngine;
using UnityEngine.EventSystems;

public class BaseScene : MonoBehaviour
{
    protected Define.Scene _scene = Define.Scene.UnKnown;


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

    public virtual void Clear() { }

}
