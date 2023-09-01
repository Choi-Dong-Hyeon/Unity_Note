using UnityEngine;

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

    SceneManagerEx scene = new SceneManagerEx();
    public SceneManagerEx Scene { get { return Instance.scene; } }

    SoundManager sound = new SoundManager();
    public SoundManager Sound { get { return Instance.sound; } }

    DataManager data = new DataManager();
    public DataManager Data { get { return Instance.data; } }

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
            DontDestroyOnLoad(go);
            instance.data.Init();
            instance.sound.Init();
        }
    }

    public void Clear()
    {
        input.Clear();
        ui.Clear();
        scene.Clear();
        sound.Clear();
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
