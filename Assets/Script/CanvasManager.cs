using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject stageSelect;
    public GameObject main;
    public GameObject startScreen;
    public GameObject Option;
    public GameObject stage1;
    // Start is called before the first frame update
    public void Startbtn()
    {
        main.SetActive(true);
        startScreen.SetActive(false);
    }

    public void Optionbtn()
    {
        Option.SetActive(true);
    }

    public void OptionBack()
    {
        Option.SetActive(false);
    }

    public void Tutorialbtn()
    {
        main.SetActive(false);
        stageSelect.SetActive(true);
    }
    public void Stage1btn()
    {
        stage1.SetActive(true);
    }

    public void SteageBackbtn()
    {
        stageSelect.SetActive(false);
        main.SetActive(true);
    }

    public void MainBack()
    {
        main.SetActive(false);
        startScreen.SetActive(true);
    }
}
