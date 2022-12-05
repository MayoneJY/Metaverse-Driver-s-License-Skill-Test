using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject stageSelect;
    public GameObject main;
    public GameObject startScreen;
    public GameObject Option;
    public GameObject stage1, stage2, stage3, stage4, stage5, stage6, stage7;
    public GameObject rulebook;
    public GameObject rule;
    // Start is called before the first frame update
    public void Startbtn() //시작화면에서 메인화면으로
    {
        main.SetActive(true);
        startScreen.SetActive(false);
    }

    public void Optionbtn() // 옵션창 띄우는거
    {
        Option.SetActive(true);
    }

    public void OptionBack() // 옵션창 닫는거
    {
        Option.SetActive(false);
    }

    public void Tutorialbtn() // 메인창에서 메인창닫고 스테이지고르는창 + 룰북버튼 띄우는거
    {
        main.SetActive(false);
        stageSelect.SetActive(true);
        rule.SetActive(true);
    }
    public void Stage1btn() // 스테이지1 설명+입장뜨게하는거
    {
        stage1.SetActive(true);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }
    public void Stage2btn() // 스테이지2 설명+입장뜨게하는거
    {
        stage1.SetActive(false);
        stage2.SetActive(true);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }

    public void Stage3btn() // 스테이지3 설명+입장뜨게하는거
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(true);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }

    public void Stage4btn() // 스테이지4 설명+입장뜨게하는거
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(true);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }

    public void Stage5btn() // 스테이지5 설명+입장뜨게하는거
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(true);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }

    public void Stage6btn() // 스테이지6 설명+입장뜨게하는거
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(true);
        stage7.SetActive(false);
    }

    public void Stage7btn() // 스테이지7 설명+입장뜨게하는거
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(true);
    }

   
    public void SteageBackbtn() // 스테이지선택창 + 룰선택 닫고 메인창띄움
    {
        stageSelect.SetActive(false);
        main.SetActive(true);
        rule.SetActive(false);
    }

    public void MainBack() // 메인창닫고 시작화면 띄우는거
    {
        main.SetActive(false);
        startScreen.SetActive(true);
    }

    public void RuleBook() // 스테이치선택창닫고 기본규칙띄우는거
    {
        stageSelect.SetActive(false);
        rulebook.SetActive(true);
    }
    public void RuleBookBack() // 기본규칙창 닫고 스테이지선택창 띄우는거
    {
        rulebook.SetActive(false);
        stageSelect.SetActive(true);
    }
}
