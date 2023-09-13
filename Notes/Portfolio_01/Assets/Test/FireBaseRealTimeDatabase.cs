using UnityEngine;
using Firebase.Database;
using Firebase;
using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Extensions;

public class FireBaseRealTimeDatabase : MonoBehaviour
{

    string _url = "https://portfolio-7f1c2-default-rtdb.firebaseio.com/";
    // DatabaseReference reference;


    void Start()
    {

        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(_url);

        //    WriteDb<StatData>("StatData_Player");

        // ReadDb();
        UpdateSetDate(1, 50, 10, 100);

    }




    public void WriteDb<T>(string path)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        TextAsset textAsset = Managers.Instance.Resource.Load<TextAsset>($"Data/{path}");

        reference.SetRawJsonValueAsync(textAsset.text);
    }





    public void ReadDb()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("playerStats");
        string key = reference.Push().Key;


        Dictionary<string, object> dic = new();
        Dictionary<int, Stat> testData = Managers.Instance.Data.playerStatDictionary;


        for (int i = 1; i < testData.Keys.Count + 1; i++)
        {
            key = reference.Push().Key;
            Dictionary<string, object> test = new();

            test.Add("level", testData[i].level);
            test.Add("attack", testData[i].attack);
            test.Add("maxhp", testData[i].maxhp);
            test.Add("speed", testData[i].speed);


            dic.Add((testData[i].level).ToString(), test);
        }

        reference.UpdateChildrenAsync(dic).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("성공");

            }
        });


        //reference.GetValueAsync().ContinueWith(task =>
        //{
        //    if (task.IsCompleted)
        //    {
        //        DataSnapshot snapshot = task.Result;
        //        // snapshot.Child("0").Child""
        //        Debug.Log(snapshot.Child("0").Child("level").Value);

        //        Debug.Log(reference.Push().Key);

        //    }

        //  });

    }



    public void UpdateSetDate(int level, int hp, int attack, int exp)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("playerStats");

        Dictionary<int, Stat> playerStatData = Managers.Instance.Data.playerStatDictionary;
        Dictionary<string, object> updateDic = new();
        Dictionary<string, object> inputDic = new();


        playerStatData[level].level = level;
        playerStatData[level].maxhp = hp;
        playerStatData[level].attack = attack;
        playerStatData[level].totalExp += exp;

        inputDic.Add("level", playerStatData[level].level);
        inputDic.Add("maxhp", playerStatData[level].maxhp);
        inputDic.Add("attack", playerStatData[level].attack);
        inputDic.Add("totalExp", playerStatData[level].totalExp);

        updateDic.Add(playerStatData[level].level.ToString(), inputDic);

        reference.UpdateChildrenAsync(updateDic).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("성공");
            }
        });
    }


    public void SetData()
    {
        // dic["level"] = 99;
    }


}





public class Data
{
    public int _lv;
    public int _hp;
    public int _speed;

    public Data(int level, int hp, int speed)
    {
        _lv = level;
        _hp = hp;
        _speed = speed;
    }
}
