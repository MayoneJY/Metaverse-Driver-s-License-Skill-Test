using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesChange : MonoBehaviour
{
    [SerializeField] private GameObject Practice;
    [SerializeField] private GameObject Main;

    public void Start()
    {
        SceneManager.LoadScene("");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PracticeBtn()
    {
        Main.SetActive(false);
        Practice.SetActive(true);
    }
}
