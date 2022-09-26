using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    private string m_currentName, m_newName;
    private float m_currentScore, m_newScore, m_highestScore;


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

    private void HereComesTheNewChallenger()
    {
        //switch (true)
        //{
        //    default:
        //        break;
        //}
    }


    [System.Serializable]
    private class SaveData
    {
        public string currentName, newName;
        public float currentScore, newScore, highestScore;

        public void SaveName()
        {
            SaveData data = new SaveData();
            data.currentName = currentName;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        public void LoadName()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                currentName = data.currentName;
            }
        }

        public void SaveHighScore()
        {
            SaveData data = new SaveData();
            data.currentScore = currentScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        public void LoadHighScore()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                currentScore = data.currentScore;
            }
        }
    }
}
