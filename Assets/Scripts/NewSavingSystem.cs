using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class NewSavingSystem 
{
    public static void SavePlayerName(NewPlayer player)
    {
        NewPlayerData data = new NewPlayerData(player);
        data.name = player._name;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static void SavePlayerScore(NewPlayer player)
    {
        NewPlayerData data = new NewPlayerData(player);
        data.score = player._score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static NewPlayerData LoadPlayerName(NewPlayer player)
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            NewPlayerData data = JsonUtility.FromJson<NewPlayerData>(json);

            player._name = data.name;

            return data;
        }
        else
        {
            return null;
        }
    }

    public static NewPlayerData LoadPlayerScore(NewPlayer player)
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            NewPlayerData data = JsonUtility.FromJson<NewPlayerData>(json);

            player._score = data.score;

            return data;
        }
        else
        {
            return null;
        }
    }
}
