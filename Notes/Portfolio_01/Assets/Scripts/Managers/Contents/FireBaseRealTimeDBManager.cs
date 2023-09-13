using UnityEngine;
using Firebase.Database;
using System.Collections.Generic;
using Firebase.Extensions;
using Firebase;
using System;

public class FireBaseRealTimeDBManager
{
    public void Init()
    {
        string _url = "https://portfolio-7f1c2-default-rtdb.firebaseio.com/";
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(_url);
    }

    public void WriteDb(Dictionary<int, Stat> type)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        string jsonData = JsonUtility.ToJson(type);
        reference.Child($"{type}").SetRawJsonValueAsync(jsonData);
    }

    public void UpdateSetDate(int level , int hp = 0, int attack = 0, int exp = 0)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("playerStats");

        Dictionary<int, Stat> playerStatData = Managers.Instance.Data.playerStatDictionary;
        Dictionary<string, object> updateDic = new();
        Dictionary<string, object> setDic = new();

        playerStatData[level].level = level;
        playerStatData[level].maxhp = hp;
        playerStatData[level].attack = attack;
        playerStatData[level].totalExp = exp;

        setDic.Add("level", playerStatData[level].level);
        setDic.Add("maxhp", playerStatData[level].maxhp);
        setDic.Add("attack", playerStatData[level].attack);
        setDic.Add("totalExp", playerStatData[level].totalExp);

        updateDic.Add(playerStatData[level].level.ToString(), setDic);

        reference.UpdateChildrenAsync(updateDic).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("¼º°ø");
            }
        });
    }

}
