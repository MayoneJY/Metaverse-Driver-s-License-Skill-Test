using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject mainMenu;
    public GameObject stageSelect;
    public GameObject stage1;
    public GameObject menu;
    public static bool menucheck = false;

    public void Tutorialtbtn()
    {
        tutorial.SetActive(true);
        mainMenu.SetActive(false);
        menu.SetActive(false);
    }

    public void StageSelectbtn()
    {
        stage1.SetActive(true);
    }

    public void Backbtn()
    {
        stageSelect.SetActive(false);
        mainMenu.SetActive(true);
        menu.SetActive(true);
    }
    
    public void Menubtn()
    {
        if (menucheck == false)
        {
            mainMenu.SetActive(true);
            menucheck = true;
        }
        else if (menucheck == true)
        {
            mainMenu.SetActive(false);
            menucheck = false;
        }

    }
}
