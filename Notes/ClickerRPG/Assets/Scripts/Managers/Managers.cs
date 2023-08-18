using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;
    static Managers Instance { get { Init(); return instance; } }

    public static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            GameObject evt = Instantiate(Resources.Load<GameObject>("Prefabs/@EventSystem"));
            evt.name = Resources.Load<GameObject>("Prefabs/@EventSystem").name;
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

    public static PlayerStat _playerStat;

    public static MonsterController _monsterController;

    void Start()
    {
        Init();
        _playerStat = FindObjectOfType<PlayerStat>();

        _monsterController = FindObjectOfType<MonsterController>();
    }

}
