using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelUnlockSystem
{
    public class LevelUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject levelBtnGridHolder;
        [SerializeField] private LevelBtn levelBtnPrefab;

        private void Start()
        {
            InitializeUI();
        }
        public void InitializeUI()
        {
            LevelItem[] levelItemAraay = LevelManager.Instance.LevelData.leveItemArray;

            for(int i = 0; i<levelItemAraay.Length; i++)
            {
                LevelBtn levelButton = Instantiate(levelBtnPrefab, levelBtnGridHolder.transform);
                levelButton.SetLevelButton(levelItemAraay[i], i, i == LevelManager.Instance.LevelData.lastUnlockedLevel);
            }
    }
}
}
