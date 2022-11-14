using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LevelUnlockSystem { 
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Image[] starsArray;
        [SerializeField] private Color lockColor, unlockColor;
        [SerializeField] private Text levelStatusText;
        [SerializeField] private GameObject overPanel;

        public void GameOver(int starCount)
        { 
            if(starCount > 0)
            {
                levelStatusText.text = "Level" + (LevelManager.Instance.CurrentLevel + 1) + " Completed";
                LevelManager.Instance.LevelComplete(starCount);
            }
            else
            {
                levelStatusText.text = "Level" + (LevelManager.Instance.CurrentLevel + 1) + "Faild";
            }
            overPanel.SetActive(true);
        }

        public void OKBtn()
        {
            SceneManager.LoadScene(0);
        }
        public void OKBtn1()
        {
            SceneManager.LoadScene(1);
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

       
        }
    }