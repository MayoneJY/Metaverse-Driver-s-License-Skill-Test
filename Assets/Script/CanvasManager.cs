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
    public void Startbtn() //����ȭ�鿡�� ����ȭ������
    {
        main.SetActive(true);
        startScreen.SetActive(false);
    }

    public void Optionbtn() // �ɼ�â ���°�
    {
        Option.SetActive(true);
    }

    public void OptionBack() // �ɼ�â �ݴ°�
    {
        Option.SetActive(false);
    }

    public void Tutorialbtn() // ����â���� ����â�ݰ� ������������â + ��Ϲ�ư ���°�
    {
        main.SetActive(false);
        stageSelect.SetActive(true);
        rule.SetActive(true);
    }
    public void Stage1btn() // ��������1 ����+����߰��ϴ°�
    {
        stage1.SetActive(true);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }
    public void Stage2btn() // ��������2 ����+����߰��ϴ°�
    {
        stage1.SetActive(false);
        stage2.SetActive(true);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }

    public void Stage3btn() // ��������3 ����+����߰��ϴ°�
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(true);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }

    public void Stage4btn() // ��������4 ����+����߰��ϴ°�
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(true);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }

    public void Stage5btn() // ��������5 ����+����߰��ϴ°�
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(true);
        stage6.SetActive(false);
        stage7.SetActive(false);
    }

    public void Stage6btn() // ��������6 ����+����߰��ϴ°�
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(true);
        stage7.SetActive(false);
    }

    public void Stage7btn() // ��������7 ����+����߰��ϴ°�
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
        stage7.SetActive(true);
    }

   
    public void SteageBackbtn() // ������������â + �꼱�� �ݰ� ����â���
    {
        stageSelect.SetActive(false);
        main.SetActive(true);
        rule.SetActive(false);
    }

    public void MainBack() // ����â�ݰ� ����ȭ�� ���°�
    {
        main.SetActive(false);
        startScreen.SetActive(true);
    }

    public void RuleBook() // ������ġ����â�ݰ� �⺻��Ģ���°�
    {
        stageSelect.SetActive(false);
        rulebook.SetActive(true);
    }
    public void RuleBookBack() // �⺻��Ģâ �ݰ� ������������â ���°�
    {
        rulebook.SetActive(false);
        stageSelect.SetActive(true);
    }
}
