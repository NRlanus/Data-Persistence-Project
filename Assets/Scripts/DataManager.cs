using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int points;
    public string playerName;
    public TextMeshProUGUI bestPlayer;
    public string newPlayer;


    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public int points;

        
    }
    public void SaveData()
    {
        PlayerData data = new PlayerData();

        data.playerName = playerName;
        data.points = points;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            points = data.points;
            playerName = data.playerName;


        }
    }
    
    public string BestPlayerInfo()
    {
        return $"Best score: {playerName}: {points}";
     }
    
    public void Awake()
    { 
            if (Instance != null)

            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadData();

        }

    //Update the score, if the newScore is higher than the one already storaged, it replaces it and it´s saved.
    public void NewScore(int newScore)
    {
        if(points<newScore)
        {
            points = newScore;
            playerName = newPlayer;

            SaveData();
        }
    }
    
}