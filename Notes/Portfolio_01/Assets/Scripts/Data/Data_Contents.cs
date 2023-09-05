using System;
using System.Collections.Generic;

#region#Stat
[Serializable]
public class Stat
{
    public int level;
    public int maxhp;
    public int attack;
    public float speed;
    public int totalExp;
}

[Serializable]
public class StatData : ILoader<int, Stat>
{
    public List<Stat> playerStats = new List<Stat>();

    public Dictionary<int, Stat> MakeDictionary()
    {
        Dictionary<int, Stat> playerDictionary = new Dictionary<int, Stat>();

        foreach (Stat stat in playerStats)
        {
            playerDictionary.Add(stat.level, stat);
        }
        return playerDictionary;
    }
}
#endregion

#region#MonsterStat
[Serializable]
public class MonstersStat
{
    public int id;
    public int hp;
    public int attack;
    public float speed;
    public int monExp;
}

[Serializable]
public class MonsterStatData : ILoader<int, MonstersStat>
{
    public List<MonstersStat> monsterStats = new List<MonstersStat>();


    public Dictionary<int, MonstersStat> MakeDictionary()
    {
        Dictionary<int, MonstersStat> monsterDictionary = new Dictionary<int, MonstersStat>();
        foreach (MonstersStat stat in monsterStats)
        {
            monsterDictionary.Add(stat.id, stat);
        }
        return monsterDictionary;
    }
}
#endregion