using System.IO;
using UnityEngine;

public class BaseStat : MonoBehaviour
{

    int _hp;
    int _mp;
    int _exp;
    int _gold;

    public int HP { get { return _hp; } set { _hp = value; } }
    public int MP { get { return _mp; } set { _mp = value; } }
    public int EXP { get { return _exp; } set { _exp = value; } }
    public int GOLD { get { return _gold; } set { _gold = value; } }


    void Awake()
    {
        Init();
    }

    protected virtual void Init() { }


    public void Save()
    {
        string path = Application.persistentDataPath + "/";
        string fileName = "";
        BaseStat asd = new BaseStat();
        string data = JsonUtility.ToJson(asd);
        File.WriteAllText(path + fileName, data);
    }




}



