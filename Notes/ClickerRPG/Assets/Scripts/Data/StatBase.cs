using UnityEngine;

public class StatBase : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] int _attack;
    [SerializeField] int _exp;
    [SerializeField] int _gold;
    
    public int HP { get { return _hp; } set { _hp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int EXP { get { return _exp; } set { _exp = value; } }
    public int GOLD { get { return _gold; } set { _gold = value; } }

    void Awake(){ Init(); }
    protected virtual void Init() { }
}
