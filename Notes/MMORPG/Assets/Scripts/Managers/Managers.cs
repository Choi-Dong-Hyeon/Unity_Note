using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;
    static Managers Instance { get { Init(); return instance; } }

    #region# Core
    InputManager input = new InputManager();
    public static InputManager Input { get { return Instance.input; } }

    ResourceManager resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance.resource; } }

    UIManager ui = new UIManager();
    public static UIManager UI { get { return Instance.ui; } }

    SceneManagerExtension scene = new SceneManagerExtension();
    public static SceneManagerExtension Scene { get { return Instance.scene; } }

    SoundManager sound = new SoundManager();
    public static SoundManager Sound { get { return Instance.sound; } }

    DataManager data = new DataManager();
    public static DataManager Data { get { return Instance.data; } }
    #endregion

    #region# Contents
    GameManager game = new GameManager();
    public static GameManager Game { get { return Instance.game; } }
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

            DontDestroyOnLoad(go);
            instance = go.GetComponent<Managers>();
            instance.sound.Init();
            instance.data.Init();
        }
    }

    void Update()
    {
        input.OnUpdate();
    }
}
