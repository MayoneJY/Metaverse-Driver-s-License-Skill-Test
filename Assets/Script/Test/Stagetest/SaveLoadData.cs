using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace LevelUnlockSystem {
    public class SaveLoadData : MonoBehaviour
    {
        private static SaveLoadData instance;
        public static SaveLoadData Instance { get => instance; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause == true)
                SaveData();
        }
        
        public void Initialize()
        {
            if(PlayerPrefs.GetInt("GameStartedFirstTime") == 1)
            {
                LoadData();
            }
            else
            {
                SaveData();
                PlayerPrefs.SetInt("GameStartedFirstTime", 1);
            }
        }

        public void SaveData()
        {
            string levelDataString = JsonUtility.ToJson(LevelManager.Instance.LevelData);

            try
            {
                File.WriteAllText(Application.persistentDataPath + "/LevelData.json", levelDataString);
                Debug.Log("Data Saved");
            }
            catch (System.Exception e)
            {
                Debug.Log("Error Saving Data" + e);
                throw;
            }
        }

        private void LoadData()
        {
            try
            {
                string levelDataString = File.ReadAllText(Application.persistentDataPath + "/LevelData.json");
                LevelData levelData = JsonUtility.FromJson<LevelData>(levelDataString);
                if(levelData != null)
                {
                    LevelManager.Instance.LevelData.leveItemArray = levelData.leveItemArray;
                    LevelManager.Instance.LevelData.lastUnlockedLevel = levelData.lastUnlockedLevel;
                }
                Debug.Log("Data Loaded");
            }
            catch (System.Exception e)
            {
                Debug.Log("Error Loading Data" + e);
                throw;
            }
        }
    }
}
