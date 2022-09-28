using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static event Action<GameData> OnDataLoaded;

    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() => LoadData();

    public void _SaveData()
    {
        GameData data = new GameData();
        data.currentName = "Hakan";

        data.currentScore = 15;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            GameData loadedData = new GameData();
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            loadedData.currentName = data.currentName;
            loadedData.currentScore = data.currentScore;
            OnDataLoaded?.Invoke(loadedData);
        }
    }


    [System.Serializable]
    public struct GameData
    {
        public string currentName;
        public float currentScore;
    }
}
