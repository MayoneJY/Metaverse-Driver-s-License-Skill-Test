using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] GameObject Plyaer;
    private Transform respawnPoint;
    public static bool GameIsPaused = false;
    public GameObject PauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resum();

                }else
                {
                Pause();
                }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resum()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene("UI");
    }

    public void ReSpawnnn()
    {
        Plyaer.transform.position = new Vector3(1, 1, 1);
        GameIsPaused = false;
    }

    

}
