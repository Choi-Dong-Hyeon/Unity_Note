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
    public List<Stat> stats = new List<Stat>();

    public Dictionary<int, Stat> MakeDictionary()
    {
        Dictionary<int, Stat> dictionary = new Dictionary<int, Stat>();

        foreach (Stat stat in stats)
        {
            dictionary.Add(stat.level, stat);
        }
        return dictionary;
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
}

[Serializable]
public class MonsterStatData : ILoader<int, MonstersStat>
{
    public List<MonstersStat> stats = new List<MonstersStat>();

    public Dictionary<int, MonstersStat> MakeDictionary()
    {
        Dictionary<int, MonstersStat> dictionary = new Dictionary<int, MonstersStat>();

        foreach (MonstersStat stat in stats)
        {
            dictionary.Add(stat.id, stat);
        }
        return dictionary;
    }
}


#endregion