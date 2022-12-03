using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesChange : MonoBehaviour
{
    [SerializeField] private GameObject Practice;
    [SerializeField] private GameObject Main;

    public void Startbtn()
    {
        SceneManager.LoadScene("");
    }
    public void Exitbtn()
    {
        Application.Quit();
    }
    public void PracticeBtn()
    {
        Main.SetActive(false);
        Practice.SetActive(true);
    }
}
