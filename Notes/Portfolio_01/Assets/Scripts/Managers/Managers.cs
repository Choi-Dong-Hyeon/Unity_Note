using UnityEngine;
using UnityEngine.EventSystems;

public class Managers : MonoBehaviour
{
    static Managers instance;
    public static Managers Instance { get { Init(); return instance; } }


    InputManager input = new InputManager();
    public InputManager Input { get { return Instance.input; } }

    ResourceManager resource = new ResourceManager();
    public ResourceManager Resource { get { return Instance.resource; } }

    UIManager ui = new UIManager();
    public UIManager UI { get { return Instance.ui; } }



    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            instance = go.GetComponent<Managers>();

            EventSystem evt = GameObject.FindObjectOfType<EventSystem>();
            if (evt == null)
            {
                evt = Instance.Resource.Instantiate<EventSystem>("@EventSystem");

            }
            DontDestroyOnLoad(go);
            DontDestroyOnLoad(evt);
        }
    }


    private void Start()
    {
        Init();
    }


    void Update()
    {
        input.UpdateMouse();
    }


}
