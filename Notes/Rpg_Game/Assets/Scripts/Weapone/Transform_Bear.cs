using UnityEngine;

public class Transform_Bear : MonoBehaviour
{
    public MonsterController[] _monsterController;

    void Start()
    {
        _monsterController = GetComponentsInChildren<MonsterController>();
    }


    void Update()
    {

        
    }
}
