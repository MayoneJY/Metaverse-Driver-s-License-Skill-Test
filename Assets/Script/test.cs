using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject mainMenu;
    public GameObject stageSelect;
    public GameObject stage1;

    public void Tutorialtbtn()
    {
        tutorial.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StageSelectbtn()
    {
        stage1.SetActive(true);
    }

    public void Backbtn()
    {
        stageSelect.SetActive(false);
        mainMenu.SetActive(true);
    }
}
