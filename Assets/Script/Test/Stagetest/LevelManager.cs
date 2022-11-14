using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelUnlockSystem
{

    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        [SerializeField]
        private LevelData levelData;
        
        public static LevelManager Instance { get => instance; }
        public LevelData LevelData { get => levelData; }

        private int currentLevel;
        public int CurrentLevel { get => currentLevel; set => currentLevel = value; }

        private void Awake()
        {
            if(instance == null) 
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SaveLoadData.Instance.SaveData();
            }
        }

        private void onEnable()
        {
            SaveLoadData.Instance.Initialize();
        }

        public void LevelComplete(int starAchieved)
        {
            if (LevelData.lastUnlockedLevel<currentLevel+1)
            {
                levelData.lastUnlockedLevel = currentLevel + 1;
                levelData.leveItemArray[levelData.lastUnlockedLevel].unlocked = true;
               // SaveLoadData.Instance.SaveData();
            }
        }
    }
    
    [System.Serializable]
    public class LevelData
    {
        public int lastUnlockedLevel = 0;
        public LevelItem[] leveItemArray;
    }

    [System.Serializable]
    public class LevelItem
    {
        public bool unlocked;
    }
}
