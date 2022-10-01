//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//public class jsonSaveManager : MonoBehaviour
//{
//    //private const string HIGHSCORE = "Highscore", NAME = "Name", CURRENT_NAME = "CurrentName";
//    public static jsonSaveManager Instance;

//    public int Score;
//    public string Name;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//        else if (Instance != null && Instance != this)
//        {
//            Destroy(gameObject);
//        }
//    } // Singleton


//    public void NewPlayerEntered(int score, string name)
//    {
//        jsonSaveManager.Instance.Score = score;
//        jsonSaveManager.Instance.Name = name;
//    }

//    [System.Serializable]
//    private class PlayerData
//    {
//        public int score, newHighscore;
//        public string name;
//        public string currentName;
//        bool isReplaceable = false;

//        public void Save()
//        {
//            PlayerData data = new PlayerData();
//            if (data.score > (int)File.GetAttributes(Application.persistentDataPath + "/savefile.json"))
//            {
//                if (data != null)
//                {
//                    data.isReplaceable = true;
//                    File.Replace(Application.persistentDataPath + "/savefile.json", data.score.ToString(), data.newHighscore.ToString());
//                }
//            }
//            else
//                data.score = score;

//            data.name = name;

//            string json = JsonUtility.ToJson(data);
//            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
//        }

//        public void Load()
//        {
//            string path = Application.persistentDataPath + "/savefile.json";
//            if (File.Exists(path))
//            {
//                string json = File.ReadAllText(path);
//                PlayerData data = JsonUtility.FromJson<PlayerData>(json);

//                score = data.isReplaceable ? data.score = data.newHighscore : data.score;
//                name = data.name;
//            }
//        }
//    }

    //public void Save(/*int score*/)
    //{

    //    //PlayerPrefs.SetInt(HIGHSCORE, score);
    //    //PlayerPrefs.SetString(NAME, PlayerPrefs.GetString(CURRENT_NAME));
    //}

    //public void Load()
    //{
    //    //PlayerPrefs.GetInt(HIGHSCORE, 0);
    //    //PlayerPrefs.GetString(NAME, " ");
    //}

    //public int GetHighestScore()
    //{
    //    return /*PlayerPrefs.GetInt(HIGHSCORE);*/
    //}

    //public string GetHighestScorerName()
    //{
    //    return /*PlayerPrefs.GetString(NAME, string.Empty);*/
    //}

    //public void SaveCurrentPlayerName(/*string currentPlayerName*/)
    //{
    //    /*PlayerPrefs.GetString(CURRENT_NAME, currentPlayerName);*/
    //}
//}
