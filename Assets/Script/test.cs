using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private void Update()
    {
        
    }
    public GameObject back;
    public GameObject Main;
    public GameObject TutorialSelect;
    public GameObject stageinfo;

    public void Tutorialbtn()
    {
        Main.SetActive(false);
        TutorialSelect.SetActive(true);
        
        
    } 

    
    
    public void StageSelectBtn()
    {
        stageinfo.SetActive(true);
        
    }
    public void Backbtn()
    {

        Main.SetActive(true);
        TutorialSelect.SetActive(false);
    }
}
