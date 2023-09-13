using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;
    public static Managers Instance { get { Init(); return instance; } }

    #region#Contents
    GameManager game = new GameManager();
    public GameManager Game { get { return Instance.game; } }

    FireBaseRealTimeDBManager realDb = new FireBaseRealTimeDBManager();
    public FireBaseRealTimeDBManager RealDb { get { return Instance.realDb; } }

    FireBaseAuthManager auth = new FireBaseAuthManager();
    public FireBaseAuthManager Auth { get { return Instance.auth; } }
    #endregion


    #region#Core
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
    #endregion

   public static void Init()
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
            instance.realDb.Init();
        }
    }

    public void Clear()
    {
        input.Clear();
        ui.Clear();
        scene.Clear();
        sound.Clear();
    }

    void Update()
    {
        input.UpdateMouse();
    }
}
