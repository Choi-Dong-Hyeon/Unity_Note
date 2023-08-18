using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;
    static Managers Instance { get { Init(); return instance; } }

    InputManager input = new InputManager();
    public static InputManager Input { get { return Instance.input; } }

    ResourceManager resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance.resource; } }

    public static void Init()
    {

        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            GameObject original = Resources.Load<GameObject>("Prefabs/@EventSystem");
            GameObject evt = Instantiate(original);
            evt.name = original.name;
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            DontDestroyOnLoad(evt);
            instance = go.GetComponent<Managers>();
        }

    }

    public static PlayerController player;
    public static PlayerStat playerStat;
    public static MonsterStat monsterStat;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        playerStat = GameObject.FindObjectOfType<PlayerStat>();
        monsterStat = GameObject.FindObjectOfType<MonsterStat>();
    }


    void Update()
    {
        input.OnUpdateKey();
    }
}
